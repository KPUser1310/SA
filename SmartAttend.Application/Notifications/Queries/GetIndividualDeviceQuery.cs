using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Notifications.DTOs;

namespace SmartAttend.Application.Notifications.Queries
{
    public class GetIndividualDeviceQuery : IRequest<List<DeviceResponse>>
    {
        public int CustomerId { get; set; }
    }

 
    public class GetIndividualDeviceQueryHandler
        : IRequestHandler<GetIndividualDeviceQuery, List<DeviceResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetIndividualDeviceQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeviceResponse>> Handle(
            GetIndividualDeviceQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Devices
                .Where(x => x.CustomerId == request.CustomerId
                           && x.IsActive && !x.Running == false)
                .Select(y => new DeviceResponse
                {
                    Id = y.Id,
                    DeviceId = y.DeviceId,
                    DeviceName = y.DeviceName,
                    Description = y.Description
                }).OrderByDescending(x => x.DeviceName)
                .ToListAsync(cancellationToken);
        }
    }
}