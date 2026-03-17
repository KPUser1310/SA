using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartAttend.MachineDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ISender Mediator;

        protected ApiControllerBase(ISender mediator)
        {
            Mediator = mediator;
        }
    }
}
