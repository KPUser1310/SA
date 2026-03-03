using MediatR;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Common.DTOs;

namespace SmartAttend.Application.Handlers
{
    public class GetPartListQuery : IRequest<PartResponseModel>
    {
        public int CustomerId { get; set; }
    }

    public class GetPartListHandler : IRequestHandler<GetPartListQuery, PartResponseModel>
    {

        private readonly IPartService _partService;
        private readonly IApplicationDbContext _context;

        public GetPartListHandler(IPartService partService, IApplicationDbContext context)
        {
            _partService = partService;
            _context = context;
        }

        public async Task<PartResponseModel> Handle(GetPartListQuery request, CancellationToken cancellationToken)
        {
            return await _partService.GetPartListAsync();
        }
    }
}