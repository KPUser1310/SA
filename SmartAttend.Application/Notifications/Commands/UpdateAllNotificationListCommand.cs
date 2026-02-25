using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.Application.Notifications.Commands
{
    public class UpdateAllNotificationListCommand : IRequest<PageResponse>
    {
        public int AccountId { get; set; }
    }

    public class UpdateAllAllNotificationListHandler : IRequestHandler<UpdateAllNotificationListCommand, PageResponse>
    {
        private readonly IApplicationDbContext _context;
        public UpdateAllAllNotificationListHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PageResponse> Handle(UpdateAllNotificationListCommand request, CancellationToken cancellationToken)
        {
            PageResponse pageResponse = new PageResponse();
            try
            {
                 _ = await _context.Notifications
                            .Where(x => x.AccountId == request.AccountId && x.IsNotify == false)
                            .ExecuteUpdateAsync(update => update.SetProperty(x => x.IsNotify, true), cancellationToken);
                
                pageResponse.IsSuccess = true;
                pageResponse.Message = "Meassge read successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return pageResponse;
        }
    }
}
