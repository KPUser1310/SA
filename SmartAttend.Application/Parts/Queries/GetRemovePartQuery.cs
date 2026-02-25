using MediatR;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Interfaces;


public class GetRemovePartQuery : IRequest<PartResponseModel>
{
    public int Id { get; set; }

    // Nested handler class
    public class Handler : IRequestHandler<GetRemovePartQuery, PartResponseModel>
    {
        private readonly IPartService _partService;

        public Handler(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<PartResponseModel> Handle(GetRemovePartQuery request, CancellationToken cancellationToken)
        {

            var response = await _partService.GetRemovePartAsync(request.Id);
            return response;
        }

    }
}