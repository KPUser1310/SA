using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Test.Commands;

namespace SmartAttend.MachineDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [Route("GetSample")]
        public async Task<IActionResult> GetSample(CancellationToken cancellationToken)
        {

            

            return Ok("GetSample added");
        }
    }

}
