using MediatR;
using SmartAttend.Application.Common.Inferfaces;
using Microsoft.EntityFrameworkCore;

namespace SmartAttend.Application.Devices.Queries.GetDevices
{
    public class GetDevicesQueryHandler
        : IRequestHandler<GetDevicesQuery, List<DeviceListDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetDevicesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeviceListDto>> Handle(GetDevicesQuery request,CancellationToken cancellationToken)
        {
            var devices = await _context.Devices
                .AsNoTracking()
                .Where(x => x.CustomerId == request.customerId && x.IsActive)
                .OrderBy(x => x.DeviceName)
                .Select(x => new DeviceListDto
                {
                    Id = x.Id,
                    DeviceName = x.DeviceName
                })
                .ToListAsync(cancellationToken);

            return devices;
        }
    }
}