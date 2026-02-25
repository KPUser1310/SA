using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Dashboard.Queries.Customer;

public sealed class GetCustomerDashboardQueryHandler
    : IRequestHandler<GetCustomerDashboardQuery, CustomerDashboardDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetCustomerDashboardQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerDashboardDto> Handle(GetCustomerDashboardQuery request,CancellationToken cancellationToken)
    {
        var machines = await _dbContext.Devices
            .AsNoTracking()
            .Where(d => d.CustomerId == request.CustomerId)
            .Select(d => new DeviceDto
            {
                DeviceId = d.DeviceId,
                DeviceName = d.DeviceName,
            })
            .ToListAsync(cancellationToken);

        return new CustomerDashboardDto
        {
            CustomerId = request.CustomerId,
            Machines = machines
        };
    }
}
