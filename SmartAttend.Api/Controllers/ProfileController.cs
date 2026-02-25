using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ApiControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _dbContext;

        public ProfileController(ICurrentUserService currentUserService,IApplicationDbContext dbContext)
        {
            _currentUserService = currentUserService;
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet("profile")]
        [ProducesResponseType(typeof(UserProfileDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProfileAsync()
        {
            var accountId = _currentUserService.AccountId;

            if (accountId <= 0)
                return Unauthorized("Invalid user context");

            var profile = await Mediator.Send(
                new GetUserProfileQuery { AccountId = accountId });

            if (profile == null)
                return Unauthorized("User not found");

            return Ok(profile);
        }

    }
}
