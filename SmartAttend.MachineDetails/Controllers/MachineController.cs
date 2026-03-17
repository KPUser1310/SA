using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Devices.Queries.GetContacts;
using SmartAttend.Application.Devices.Queries.GetDeviceConfiguration;
using SmartAttend.Application.Devices.Queries.GetDevices;
using SmartAttend.Application.Devices.Queries.SaveDeviceConfiguration;
using SmartAttend.Application.Machine.Commands;
using SmartAttend.Application.Machine.DTOs;
using SmartAttend.Application.Machine.Queries;

namespace SmartAttend.MachineDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ApiControllerBase
    {
        public MachineController(ISender mediator) : base(mediator)
        {

        }

        [HttpPost("GetMachineList")]
        [ProducesResponseType(typeof(MachineListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMachineList(GetMachineListQuery request, CancellationToken cancellationToken)
        {

            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpPost("GetDevices")]
        [ProducesResponseType(typeof(DeviceListDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDevices(
                    [FromBody] GetDevicesQuery request,
                    CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost("GetDeviceConfiguration")]
        [ProducesResponseType(typeof(DeviceConfigurationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDeviceConfiguration([FromBody] GetDeviceConfigurationQuery request,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost("SaveDeviceConfiguration")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveDeviceConfiguration([FromForm] SaveDeviceConfigurationCommand request,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost("GetContacts")]
        [ProducesResponseType(typeof(List<ContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContacts([FromBody] GetContactsQuery request,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetTestImage")]
        public async Task<IActionResult> test()
        {
            string fileName = "215f3aa8-58b6-454e-9923-3a38f2477ecd.jpg";
            string imageUrl = $"{Application.Common.Constant.Constant.MachineImageUrl}/{fileName}";
            return Ok(imageUrl);
        }

        [HttpPost("addInputContactForMachine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddInputContactForMachine([FromBody] AddInputContactForMachineCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("deleteInputContactForMachine/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteInputContactForMachine(long id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new DeleteInputContactForMachineCommand {DeviceUserMapId = id }, cancellationToken);
            return Ok(result);
        }
    }
}
