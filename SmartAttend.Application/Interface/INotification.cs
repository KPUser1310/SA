
using SmartAttend.Application.Notifications.DTOs;
using SmartAttend.Application.Notifications.Queries;

namespace SmartAttend.Application.Interface
{
    public interface INotification
    {
        Task<NotificationMachineResponse> NotificationListAsync(GetNotificationListQuery notificationRequestModel, CancellationToken cancellationToken);

        Task<List<SelectListItem>> NotifyAccountListAsync(CancellationToken cancellationToken);
        Task<List<SelectListItem>> NotifyDeviceListAsync(CancellationToken cancellationToken);

    }
}