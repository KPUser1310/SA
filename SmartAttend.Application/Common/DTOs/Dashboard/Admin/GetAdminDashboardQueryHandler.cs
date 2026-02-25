using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Dashboard.Queries.Admin;

public sealed class GetAdminDashboardQueryHandler
    : IRequestHandler<GetAdminDashboardQuery, AdminDashboardDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAdminDashboardQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AdminDashboardDto> Handle(GetAdminDashboardQuery request,CancellationToken cancellationToken)
    {
        var customers = await _dbContext.Customers
            .AsNoTracking()
            .Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CompanyName,
                Status = c.Status ?? false
            })
            .ToListAsync(cancellationToken);

        return new AdminDashboardDto
        {
            Customers = customers
        };
    }
}
