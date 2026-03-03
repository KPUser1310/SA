using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;
using SmartAttend.Application.Parts.DTOs;

namespace SmartAttend.Application.Parts.Commands
{
    // Command
    public class UpdatePartCommand : IRequest<PartResponseModel>
    {
        public UpdatePartDtos Model { get; set; }

        public UpdatePartCommand( UpdatePartDtos model)
        {
            
            Model = model;
        }
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

            // Delegate to service
            return await _partService.UpdatePartAsync(request.Model);
        }
    }
}
