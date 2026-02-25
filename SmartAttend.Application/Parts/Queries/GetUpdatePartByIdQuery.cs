
using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Common.DTOs;

namespace SmartAttend.Application.Handlers
{
    public class GetUpdatePartByIdQuery : IRequest<PartResponseModel>
    {
        public int Id { get; set; }
    }

    public class GetUpdatePartByIdHandler : IRequestHandler<GetUpdatePartByIdQuery, PartResponseModel>
    {
        private readonly IPartService _partService;
        public GetUpdatePartByIdHandler(IPartService partService)
        {
            _partService = partService;
        }
        public async Task<PartResponseModel> Handle(GetUpdatePartByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
                throw new ArgumentException("Id cannot be zero.");
            return await _partService.GetUpdatePartbyIdAsync(request.Id);
        }
    }
}
