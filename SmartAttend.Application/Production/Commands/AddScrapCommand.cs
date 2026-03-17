using MediatR;
using SmartAttend.Application.Interface;
using SmartAttend.Application.Production.DTOs;

namespace SmartAttend.Application.Production.Commands
{
    // Command
    public class AddScrapCommand : IRequest<AddScrapResponseDto>
    {
        public AddScrapDto Model { get; set; }
        public AddScrapCommand(AddScrapDto model)
        {
            Model = model;
        }
    }

    // Handler
    public class AddScrapHandler : IRequestHandler<AddScrapCommand, AddScrapResponseDto>
    {
        private readonly IProductionService _productionService;

        public AddScrapHandler(IProductionService productionService)
        {
            _productionService = productionService;
        }

        public async Task<AddScrapResponseDto> Handle(AddScrapCommand request, CancellationToken cancellationToken)
        {
            if (request.Model == null)
                throw new ArgumentNullException(nameof(request.Model));

            return await _productionService.AddScrapAsync(request.Model);
        }
    }
}