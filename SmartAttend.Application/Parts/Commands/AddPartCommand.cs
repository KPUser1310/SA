using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Handlers
{
    // Command
    public class AddPartCommand : IRequest<PartResponseModel>
    {
        public AssignedPart Model { get; set; }
    }

    // Handler
    public class AddPartHandler : IRequestHandler<AddPartCommand, PartResponseModel>
    {
        private readonly IPartService _partService;

        public AddPartHandler(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<PartResponseModel> Handle(AddPartCommand request, CancellationToken cancellationToken)
        {
            if (request.Model == null)
                throw new ArgumentNullException(nameof(request.Model));

            // Delegate to your existing service method
            return await _partService.AddPartAsync(request.Model);
        }
    }
}