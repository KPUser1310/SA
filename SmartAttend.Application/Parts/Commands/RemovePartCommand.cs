using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.DTOs;

namespace SmartAttend.Application.Handlers
{
    public class RemovePartCommand : IRequest<PartResponseModel>
    {
        public int Id { get; set; }    
    }

    public class RemovePartHandler : IRequestHandler<RemovePartCommand, PartResponseModel>
    {
        private readonly IPartService _partService;

        public RemovePartHandler(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<PartResponseModel> Handle(RemovePartCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                throw new ArgumentException("Invalid Part Id");

            return await _partService.RemovePartAsync(request.Id);
        }
    }
}
