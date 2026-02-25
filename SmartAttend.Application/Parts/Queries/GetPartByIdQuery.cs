using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.DTOs;

namespace SmartAttend.Application.Handlers
{
    public class GetPartByIdQuery : IRequest<PartResponseModel>
    {
        public int Id { get; set; }

        public class GetPartByIdHandler : IRequestHandler<GetPartByIdQuery, PartResponseModel>
        {
            private readonly IPartService _partService;

            public GetPartByIdHandler(IPartService partService)
            {
                _partService = partService;
            }

            public async Task<PartResponseModel> Handle(GetPartByIdQuery request, CancellationToken cancellationToken)
            {
                if (request.Id <= 0)
                    throw new ArgumentException("Invalid Part Id");

                return await _partService.GetPartByIdAsync(request.Id);
            }
        }
    }
}
