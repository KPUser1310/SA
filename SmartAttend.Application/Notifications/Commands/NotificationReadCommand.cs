using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.Application.Notifications.Commands
{
    public class NotificationReadCommand : IRequest<PageResponse>
    {
        public int NotificationId { get; set; }
    }

    public class NotificationReadHandler : IRequestHandler<NotificationReadCommand, PageResponse>
    {
        private readonly IApplicationDbContext _context;

        public NotificationReadHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PageResponse> Handle(NotificationReadCommand request,CancellationToken cancellationToken)
        {
            PageResponse Response = new PageResponse();
            try
            {
                var result = await _context.Notifications
                            .Where(x => x.Id == request.NotificationId).FirstOrDefaultAsync(cancellationToken);

                if(result == null)
                {
                    return new PageResponse() { IsSuccess = false, Message = "Notification ID not Exist" };                        
                }

                 _ = await _context.Notifications.AsNoTracking()
                                                 .Where(x => x.DeviceId == result.DeviceId
                                                          && x.AccountId == result.AccountId
                                                          && x.IsNotify == false)
                                                 .ExecuteUpdateAsync(updates => updates
                                                     .SetProperty(x => x.IsNotify, true)
                                                     .SetProperty(x => x.UpdatedDate, DateTime.Now), 
                                                     cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                Response.IsSuccess = true;
                Response.Message = "Notification Successfully Read";
                return Response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
