using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Machine.Commands;
using SmartAttend.Application.Machine.DTOs;
using SmartAttend.Application.Machine.Queries;
using SmartAttend.WebApi.Controllers;

namespace SmartAttend.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSeedController : ApiControllerBase
    {
        public DataSeedController() { }


        [HttpPost("AddMachine")]
        [ProducesResponseType(typeof(PageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMachineList(CreateMachineRequest request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new AddMachineCommand { createMachineRequest = request }, cancellationToken);
            return Ok(result);
        }



    }
}
