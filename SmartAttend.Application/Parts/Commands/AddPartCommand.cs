using MediatR;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartAttend.Application.Parts.Commands
{
    public class AddPartCommand : IRequest<PartResponseModel>
    {
        public PartDtos Model { get; set; }

        public AddPartCommand(PartDtos model)
        {
            Model = model;
        }
    }
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

            // Delegate to your service method
            return await _partService.AddPartAsync(request.Model);
        }
    }
}
