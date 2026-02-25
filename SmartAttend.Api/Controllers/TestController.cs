using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartAttend.Application.Test.Commands;

namespace SmartAttend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiControllerBase
    {
        public TestController() { }

        [HttpPost]
        [Route("CreateSample")]
        public async Task<IActionResult> Create(SampleCreateCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSample")]
        public async Task<IActionResult> GetSample(CancellationToken cancellationToken)
        {

            var correlationId = HttpContext.Request.Headers["X-Correlation-ID"].ToString();
           
            return Ok("GetSample added");
        }
    }
}
