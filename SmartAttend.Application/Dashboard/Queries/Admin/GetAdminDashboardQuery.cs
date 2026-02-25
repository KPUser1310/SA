using MediatR;
using SmartAttend.Application.Common.DTOs;

namespace SmartAttend.Application.Dashboard.Queries.Admin
{
    public sealed class GetAdminDashboardQuery : IRequest<AdminDashboardDto>
    {
    }
}
