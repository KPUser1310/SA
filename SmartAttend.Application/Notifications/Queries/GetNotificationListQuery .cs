using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Enums;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Notifications.DTOs;
using SmartAttend.Domain.Entities;
using MediatR;
using INotification = SmartAttend.Application.Interface.INotification;

namespace SmartAttend.Application.Notifications.Queries
{
    public class GetNotificationListQuery : IRequest<NotificationResponse>
    {
        public int AccountId { get; set; }

        public long? DeviceId { get; set; }

        public int PageNo { get; set; } = 1;
        public int Size { get; set; } = 25;
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public NotificationReadType NotificationType { get; set; }

        public int Search { get; set; } = 0;
    }

    public class GetNotificationListHandler : IRequestHandler<GetNotificationListQuery, NotificationResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly INotification _notification;
        public GetNotificationListHandler(IApplicationDbContext context, INotification notification)
        {
            _context = context;
            _notification = notification;
        }

        public async Task<NotificationResponse> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                NotificationResponse notification = new NotificationResponse();
           
                var notificationTask = _notification.NotificationListAsync(request, cancellationToken);
                var accountTask = _notification.NotifyAccountListAsync(cancellationToken);
                var deviceTask = _notification.NotifyDeviceListAsync(cancellationToken);

                await Task.WhenAll(notificationTask, accountTask, deviceTask);

                notification.NotificationList = await notificationTask;
                notification.AccountList = await accountTask;
                notification.DeviceList = await deviceTask;

                return notification;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}