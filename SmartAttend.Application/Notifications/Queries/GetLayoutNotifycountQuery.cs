using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
namespace SmartAttend.Application.Notifications.Queries
{
    public class GetLayoutNotifyCountQuery : IRequest<long>
    {
        public int AccountId { get; set; }
    }

    public class GetLayoutNotifycountQueryHandler : IRequestHandler<GetLayoutNotifyCountQuery, long>
    {
        private readonly IApplicationDbContext _context;
        public GetLayoutNotifycountQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(GetLayoutNotifyCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Notifications.AsNoTracking()
                    .CountAsync(x => x.AccountId == request.AccountId 
                           && (x.IsNotify == false || x.IsNotify == null), cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
