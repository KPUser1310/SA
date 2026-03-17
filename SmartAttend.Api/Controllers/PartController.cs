using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Dashboard.Queries.Admin;
using SmartAttend.Application.Handlers;
using SmartAttend.Application.Parts.Commands;
using SmartAttend.Application.Parts.DTOs;
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

        [HttpGet("getPartList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize]
        public async Task<IActionResult> GetPartList()
        {
            
            var response = await Mediator.Send(new GetPartListQuery());

            return Ok(response);
        }

        [HttpPost("updatePart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartAsync(UpdatePartDtos model)
        {
            if (model == null) 
                return BadRequest("Model cannot be null.");
            var command = new UpdatePartCommand(model);
          var response = await Mediator.Send(command); 
            if (!response.IsSuccess) 
                return BadRequest(response.Message); 
            return Ok(response); 
        }
        
        [HttpPost("addPart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPart([FromBody] PartDtos model)
        {
            if (model == null)
                return BadRequest("Model cannot be null.");

             var command = new AddPartCommand(model);
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