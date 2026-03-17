using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Interface;
using SmartAttend.Application.Parts.Commands;
using SmartAttend.Application.Parts.DTOs;
using SmartAttend.Application.Production.Commands;
using SmartAttend.Application.Production.DTOs;
using SmartAttend.Application.Production.Queries;
using SmartAttend.Application.Production.Services;
using SmartAttend.Domain.Entities;

namespace SmartAttend.WebApi.Controllers
{
    [Route("api/Production")]
    [ApiController] 
    public class ProductionController : ApiControllerBase
    { 
        private readonly IProductionService _productionService; 
        public ProductionController(IProductionService productionService) 
        { 
            _productionService = productionService; 
        }

        [HttpGet("getAssignedParts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAssignedParts() 
        { 
            var response = await Mediator.Send(new GetAssignedPartsQuery());

            if (!response.IsSuccess || response.AssignedPartDetails == null || response.AssignedPartDetails.Count == 0) 

                return NotFound(response.Message); 

            return Ok(response); 
        }

        [HttpPut("updateAssignedPart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAssignedPart([FromBody] UpdateAssignedPartDtos dto, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new UpdateAssignedPartCommand(dto), cancellationToken);

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

    }
}