using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class Account  : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public int? CustomerId { get; set; }
        public int UserRoleId { get; set; }
        public string? ContactPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool? IsTempPassword { get; set; }
        public bool Status { get; set; }
        public bool? IsVocationMode { get; set; }
        public DateTime? VacationDateFrom { get; set; }
        public DateTime? VacationDateTo { get; set; }
        public bool IsEmailNotification { get; set; } = false;
        public bool? IsDelete { get; set; }
        public string Image { get; set; }  
        public bool IsDragAndDrop { get; set; } = false;
        public string? AzureObjectId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(UserRoleId))]
        public virtual UserRole UserRole { get; set; }

        public ICollection<CycleNotification> CycleNotifications { get; set; }
        public ICollection<CycleUserMap> CycleUserMaps { get; set; }
        public ICollection<DeviceUserReport> DeviceUserReports { get; set; }
        public ICollection<DeviceUserReportAccount> DeviceUserReportAccounts { get; set; }
        public ICollection<DeviceUserReportMap> DeviceUserReportMaps { get; set; }
        public ICollection<DragAndDrop> DragAndDrops { get; set; }
        public ICollection<EmailQueue> EmailQueues { get; set; }
        public ICollection<GraphDragAndDrop> GraphDragAndDrops { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<NotificationOld> NotificationOld { get; set; }
        public ICollection<NotificationHistory> NotificationHistorys { get; set; }
        public ICollection<OrderByDevice> OrderByDevices { get; set; }
        public ICollection<QuickReportSetting> QuickReportSettings { get; set; }
        public ICollection<ReportSettings> ReportSettings { get; set; }
        public ICollection<SchedulerUpdate> SchedulerUpdates { get; set; }
        public ICollection<Skids> Skids { get; set; }
        public ICollection<SmartAuthentication> SmartAuthentications { get; set; }
        public ICollection<WorkingDays> WorkingDays { get; set; }
    }
}
