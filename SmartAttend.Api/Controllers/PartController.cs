using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Handlers;
using SmartAttend.Domain.Entities;
using SmartAttend.WebApi.Controllers;


namespace SmartAttend.API.Controllers
{
    [Route("api/Part")]
    [ApiController]
    public class PartController : ApiControllerBase
    {
        public PartController()
        {

        }

        [HttpGet("getPartList/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        public async Task<IActionResult> GetPartList(int customerId)
        {
            if (customerId == 0)
                return BadRequest("CustomerID cannot be zero.");

            var query = new GetPartListQuery { CustomerId = customerId };
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("getUpdatePartbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUpdatePartbyID(int id)
        {
            if (id == 0)
                return BadRequest("Id cannot be zero.");

            var query = new GetUpdatePartByIdQuery { Id = id };
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpPut("updatePart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePart([FromBody] AssignedPart model)
        {
            if (model == null)
                return BadRequest("Model cannot be null.");

            var command = new UpdatePartCommand { Model = model };
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("getRemovePart/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRemovePart(int id)
        {
            if (id == 0)
                return BadRequest("Id cannot be zero.");

            // Create and send the command via MediatR
            var response = await Mediator.Send(new GetRemovePartQuery { Id = id });

            return Ok(response);
        }

        [HttpPost("addPart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPart([FromBody] AssignedPart model)
        {
            if (model == null)
                return BadRequest("Model cannot be null.");

            var command = new AddPartCommand { Model = model };
            var response = await Mediator.Send(command);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpDelete("removePart/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemovePart(int id)
        {
            var command = new RemovePartCommand { Id = id };
            var response = await Mediator.Send(command);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok(response);
        }

        [HttpGet("getPartbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPartbyId(int id)
        {
            {
                var query = new GetPartByIdQuery { Id = id };
                var response = await Mediator.Send(query);

                if (!response.IsSuccess)
                    return NotFound(response.Message);

                return Ok(response);
            }
        }
    }
}