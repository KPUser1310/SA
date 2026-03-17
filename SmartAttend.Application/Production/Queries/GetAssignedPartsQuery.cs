using MediatR;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Interface;
using SmartAttend.Application.Parts.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace SmartAttend.Application.Production.Queries
{
    public record GetAssignedPartsQuery() : IRequest<AssignedPartsResponseModel>;
    public class GetAssignedPartsHandler : IRequestHandler<GetAssignedPartsQuery, AssignedPartsResponseModel> 
    { 
        private readonly IProductionService _productionService; 
        public GetAssignedPartsHandler(IProductionService productionService) 
        { 
            _productionService = productionService;
        } 
        public async Task<AssignedPartsResponseModel> Handle(GetAssignedPartsQuery request, CancellationToken cancellationToken) 
        {
            return await _productionService.GetAssignedPartsAsync(); 
        } 
    }
}
