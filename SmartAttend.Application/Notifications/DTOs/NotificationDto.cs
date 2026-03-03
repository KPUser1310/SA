using Microsoft.AspNetCore.Mvc.Rendering;
using SmartAttend.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Application.Notifications.DTOs
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public long? DeviceId { get; set; }
        public int AccountId { get; set; }

        public string InputName { get; set; }
        public string Message { get; set; }
        public string CustomMessage { get; set; }
        public bool? IsNotify { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeviceDataUserMapId { get; set; }
        public DateTime? SentDate { get; set; }

        public string ContactFromHours { get; set; }
        public string ContactToHours { get; set; }

        public int? ReminderMinutes { get; set; }
        public bool IsDelete { get; set; }
        public int? EntityType { get; set; }
        public string CompletedReason { get; set; }

        // Computed / UI properties
        public string DeviceName { get; set; }
        public bool CustomerExists { get; set; }
        public int NotificationCount { get; set; }
        public int DeviceNotificationCount { get; set; }
        public string ColorCode { get; set; }
        public int RowNumber { get; set; }

        // public List<PlannedShutdownDescriptionDto> PlannedShutdowns { get; set; }

        public bool Exists { get; set; }
        public string DaysAgo { get; set; }
        public int IsShutdown { get; set; }
        public string OtherShutdown { get; set; }
        public string OtherDowntime { get; set; }

        // public List<SelectListItemDto> AccountList { get; set; }
        // public List<SelectListItemDto> DeviceList { get; set; }
        public int SelectedAccountId { get; set; }

        public string TimeZone { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }

    public class NotificationMachineResponse
    {
        public List<NotificationDto> notifications { get; set; } = new();

        public int TotalCount { get; set; }
    }






    public class NotificationResponse
    {
        public NotificationMachineResponse NotificationList { get; set; }
        public List<SelectListItem> AccountList { get; set; }
        public List<SelectListItem> DeviceList { get; set; }
    }

}