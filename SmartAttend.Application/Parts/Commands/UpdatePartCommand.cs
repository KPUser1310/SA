using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Handlers
{
    // Command
    public class UpdatePartCommand : IRequest<PartResponseModel>
    {
        public AssignedPart Model { get; set; }
    }

    // Handler
    public class UpdatePartHandler : IRequestHandler<UpdatePartCommand, PartResponseModel>
    {
        private readonly IPartService _partService;

        public UpdatePartHandler(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<PartResponseModel> Handle(UpdatePartCommand request, CancellationToken cancellationToken)
        {
            if (request.Model == null)
                throw new ArgumentNullException(nameof(request.Model));

            // Delegate to your existing service method
            return await _partService.UpdatePartAsync(request.Model);
        }
    }
}