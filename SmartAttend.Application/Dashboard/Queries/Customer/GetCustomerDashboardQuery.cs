using MediatR;
using SmartAttend.Application.Common.DTOs;

namespace SmartAttend.Application.Dashboard.Queries.Customer
{
    public sealed class GetCustomerDashboardQuery : IRequest<CustomerDashboardDto>
    {
        public int CustomerId { get; set; }
    }
}
