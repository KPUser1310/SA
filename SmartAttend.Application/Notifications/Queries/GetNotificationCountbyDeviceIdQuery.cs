using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Notifications.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Notifications.Queries
{
    public class GetNotificationCountbyDeviceIdQuery : IRequest<NotificationDeviceResponse>
    {
        public int AccountId { get; set; }
    }

    public class GetNotificationCountbyDeviceIdHandler : IRequestHandler<GetNotificationCountbyDeviceIdQuery, NotificationDeviceResponse>
    {
        private readonly IApplicationDbContext _context;
        public GetNotificationCountbyDeviceIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NotificationDeviceResponse> Handle(GetNotificationCountbyDeviceIdQuery request, CancellationToken cancellationToken)
        {
            NotificationDeviceResponse notifyCountbyDevice = new NotificationDeviceResponse();
            List<NotificationDetails> notificationList = new List<NotificationDetails>();
            try
            {
                var result = await (from note in _context.Notifications.AsNoTracking()
                             join dev in _context.Devices.AsNoTracking() on note.DeviceId equals dev.DeviceId
                             where note.AccountId == request.AccountId && dev.IsActive && note.IsNotify == false
                             group note by note.DeviceId into g
                             select g.OrderByDescending(t => t.UpdatedDate).FirstOrDefault()).Take(5).ToListAsync();

                if(result == null || !result.Any())
                {
                    return new NotificationDeviceResponse() { IsSuccess = false };
                }

                var deviceIds =  result.Select(x => x.DeviceId).ToList();
                var inputNames  = result.Select(x => x.InputName).ToList();

                var notificationCount = await _context.Notifications.AsNoTracking()
                                        .Where(x => x.AccountId == request.AccountId && x.IsNotify == false)
                                        .CountAsync(cancellationToken);     

                var deviceDataMapInput = await _context.DeviceDataMaps.AsNoTracking()
                                    .Where(y => deviceIds.Contains(y.DeviceId) && inputNames.Contains(y.InputName))
                                    .ToListAsync(cancellationToken);

                var deviceNotificationcount = await _context.Notifications.AsNoTracking()
                                        .Where(y => deviceIds.Contains(y.DeviceId) && y.AccountId == request.AccountId && y.IsNotify == false)
                                        .CountAsync(cancellationToken);

                foreach(var item in result)
                {
                    NotificationDetails notification = new NotificationDetails();
                    var color =  GetNotificationColor(item, deviceDataMapInput);
                    notification.Id = item.Id;
                    notification.DeviceName = item.Device.DeviceName;
                    notification.DeviceDataUserMapId = item.DeviceDataUserMapId == null ? 0 : item.DeviceDataUserMapId;
                    notification.InputName = item.InputName;
                    notification.DeviceId = item.DeviceId ?? 0;
                    notification.Notifycount = notificationCount;
                    notification.DeviceNotifycount = deviceNotificationcount;
                    notification.Message = item.Message;
                    notification.Color = color;
                    notificationList.Add(notification);
                }
                notifyCountbyDevice.IsSuccess = true;
                notifyCountbyDevice.Message = "Success";
                notifyCountbyDevice.NotificationDeviceModelDetails = notificationList;

            }
            catch (Exception)
            {

                throw;
            }
            return notifyCountbyDevice;
        }

        private string GetNotificationColor(Notification item, List<DeviceDataMap> devicedataMaps)
        {
            string color;
            string input;

            if (item.Message.Contains("Reminder Stopped"))
            {
                color = "#F05254";
            }
            else if (item.Message.Contains("Stopped"))
            {
                color = "#F05254";
            }
            else if (item.Message.Contains("Running"))
            {
                color = "#65BD5D";
            }
            else if (item.Message.Contains("communicating"))
            {
                color = "#137ac4";
            }
            else
            {
                input = devicedataMaps
                    .Where(x => x.DeviceId == item.DeviceId && x.InputName == item.InputName)
                    .Select(x => x.Input)
                    .FirstOrDefault();

                color = GetColor(input);
            }

            return color;
        }
        public string GetColor(string input)
        {
            string color = "";
            switch (input)
            {
                case "Input1":
                    color = "#e58585";
                    // color = "#94A897";
                    break;
                case "Input2":
                    color = "#FF9714";
                    break;
                case "Input3":
                    color = "#E67FF4";
                    break;
                case "Input4":
                    color = "#34E5C8";
                    break;
                case "Input5":
                    color = "#a041f4";
                    // color = "#1A8FFF";
                    break;
                case "Input6":
                    color = "#800000";
                    break;
            }
            return color;
        }




    }
}
