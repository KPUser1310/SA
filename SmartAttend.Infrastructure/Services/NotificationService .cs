using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Enums;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Interface;
using SmartAttend.Application.Notifications.DTOs;
using SmartAttend.Application.Notifications.Queries;
using System.Data;


namespace SmartAttend.Infrastructure.Services.Notifications
{
    public class NotificationService : INotification
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDapperConnectionFactory _dapperConnectionFactory;
        private readonly IApplicationDbContext _context;
        public NotificationService(ICurrentUserService currentUserService, IDapperConnectionFactory dapperConnectionFactory, IApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _dapperConnectionFactory = dapperConnectionFactory;
            _context = context;
        }
        public async Task<NotificationMachineResponse> NotificationListAsync(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int skip = request.Size * (request.PageNo - 1);
                int pageNo = request.PageNo;
                NotificationMachineResponse notificationDetails = new NotificationMachineResponse();
                
                notificationDetails.notifications = new();

                var query = (from n in _context.Notifications
                             join d in _context.Devices on n.DeviceId equals d.Id
                             where n.AccountId == request.AccountId && n.IsNotify == false
                             orderby n.UpdatedDate descending
                             select new NotificationDto
                             {
                                 Id = n.Id,
                                 DeviceId = n.DeviceId,
                                 AccountId = n.AccountId,
                                 DeviceDataUserMapId = n.DeviceDataUserMapId,
                                 InputName = n.InputName,
                                 DeviceName = d.DeviceName,
                                 Message = n.Message,
                                 CustomMessage = n.CustomMessage,
                                 ContactFromHours = n.ContactFromHours,
                                 ContactToHours = n.ContactToHours,
                                 ReminderMinutes = n.Reminder,
                                 SentDate = n.SentDate,
                                 IsNotify = n.IsNotify,
                                 IsDelete = n.IsDelete,
                                 EntityType = n.EntityType,
                                 CompletedReason = n.CompletedReason,
                                 CreatedDate = n.CreatedDate,
                                 UpdatedDate = n.UpdatedDate
                             }).AsQueryable();

                if (request.DeviceId is not null)
                {
                    query = query.Where(x => x.DeviceId == request.DeviceId);
                }

                if (request.NotificationType == NotificationReadType.Read)
                {
                    query = query.Where(n => n.IsNotify == true);
                }
                else if (request.NotificationType == NotificationReadType.UnRead)
                {
                    query = query.Where(n => n.IsNotify == false);
                }

                if (request.DeviceId.HasValue && request.DeviceId.Value > 0)
                {
                    query = query.Where(n => n.DeviceId == request.DeviceId.Value);
                }

                if (!string.IsNullOrEmpty(request.FromDate) && !string.IsNullOrEmpty(request.ToDate))
                {
                    DateTime from = DateTime.Parse(request.FromDate);
                    DateTime to = DateTime.Parse(request.ToDate);

                    query = query.Where(n => n.CreatedDate >= from && n.CreatedDate <= to);
                }

                query = query.OrderByDescending(n => n.UpdatedDate);

                notificationDetails.TotalCount = await query.CountAsync();

                notificationDetails.notifications = await query
                        .Skip(skip)
                        .Take(request.Size)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);

                notificationDetails.notifications.ForEach(x =>
                {
                    x.StartDate = Convert.ToString(TZIConvertTimeZone(x.CreatedDate.Value, x.TimeZone));
                    x.EndDate = Convert.ToString(TZIConvertTimeZone(Convert.ToDateTime(x.UpdatedDate), x.TimeZone));
                });

                return notificationDetails;           
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SelectListItem>> NotifyAccountListAsync(CancellationToken cancellationToken)
        {
            int CustomerID = _currentUserService.AccountId;

            return await (from acc in _context.Accounts
                          where acc.CustomerId == CustomerID && acc.Status == true && acc.IsDelete == false
                          orderby acc.FirstName
                          select new SelectListItem
                          {
                              Text = acc.FirstName != null && acc.FirstName != "" ? acc.FirstName + " " + acc.LastName : acc.AccountId.ToString(),
                              Value = acc.AccountId.ToString(),
                              Selected = false
                          }).ToListAsync(cancellationToken);
        }

        public async Task<List<SelectListItem>> NotifyDeviceListAsync(CancellationToken cancellationToken)
        {
            int CustomerID = _currentUserService.AccountId;

            return await (from dev in _context.Devices
                          where dev.CustomerId == CustomerID && dev.IsActive == true
                          orderby dev.DeviceName
                          select new SelectListItem
                          {
                              Text = (dev.DeviceName == null || dev.DeviceName == "") ? dev.DeviceId.ToString() : dev.DeviceName,
                              Value = dev.DeviceId.ToString(),
                              Selected = false
                          }).ToListAsync(cancellationToken);
        }

        public DateTime TZIConvertTimeZone(DateTime DateTimeValue, string TimeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId);
            return TimeZoneInfo.ConvertTime(DateTimeValue, timeZone);
        }
    }
}