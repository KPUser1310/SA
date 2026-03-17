using MediatR;
using SmartAttend.Application.Parts.DTOs;
using SmartAttend.Application.Interface;

namespace SmartAttend.Application.Parts.Commands
{
    public class UpdateAssignedPartCommand : IRequest<AssignedPartsResponseModel>
    {
        public UpdateAssignedPartDtos Model { get; }

        public UpdateAssignedPartCommand(UpdateAssignedPartDtos model)
        {
            Model = model;
        }
    }

    public class UpdateAssignedPartHandler : IRequestHandler<UpdateAssignedPartCommand, AssignedPartsResponseModel>
    {
        private readonly IProductionService _productionService;

        public UpdateAssignedPartHandler(IProductionService productionService)
        {
            _productionService = productionService;
        }

        public async Task<AssignedPartsResponseModel> Handle(UpdateAssignedPartCommand request, CancellationToken cancellationToken)
        {
            if (request.Model == null)
                throw new ArgumentNullException(nameof(request.Model));

            return await _productionService.UpdateAssignedPartAsync(request.Model, cancellationToken);
        }
    }
}
