using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Dashboard.Queries.Admin;
using SmartAttend.Application.Dashboard.Queries.Customer;
//using SmartAttend.Domain.Enums;

namespace SmartAttend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ApiControllerBase
    {
        private readonly ICurrentUserService _currentUserService;

        public DashboardController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetDashboardAsync()
        {
            if (_currentUserService.UserRoleId == (int)UserRoleType.Admin)
            {
                var adminDashboard =
                    await Mediator.Send(new GetAdminDashboardQuery());

                return Ok(adminDashboard);
            }

            if (_currentUserService.UserRoleId == (int)UserRoleType.Customer)
            {
                if (!_currentUserService.CustomerId.HasValue)
                    return Forbid("Customer context not found");

                var customerDashboard =
                    await Mediator.Send(new GetCustomerDashboardQuery
                    {
                        CustomerId = _currentUserService.CustomerId.Value
                    });

                return Ok(customerDashboard);
            }

            return Forbid("Access denied for this role");
        }
    }
}
