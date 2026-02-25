using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartAttend.Domain.Entities;


namespace SmartAttend.Application.Common.Inferfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssignedPart> AssignedParts { get; set; }
        public DbSet<AssignedPartsHistory> AssignedPartsHistories { get; set; }
        public DbSet<AssignMultiPart> AssignMultiParts { get; set; }
        //   public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<CalendarShiftTime> CalendarShiftTimes { get; set; }
        public DbSet<ContactSupportMail> ContactSupportMails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerShift> CustomerShifts { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerWeekDay> CustomerWeekDays { get; set; }
        public DbSet<CycleMaintenance> CycleMaintenances { get; set; }
        public DbSet<CycleNotification> CycleNotifications { get; set; }
        public DbSet<CycleUserMap> CycleUserMaps { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceConfig> DeviceConfigs { get; set; }
        public DbSet<DeviceConfigDetails> DeviceConfigDetails { get; set; }
        public DbSet<DeviceData> DeviceDatas { get; set; }
        public DbSet<DeviceDataHistory> DeviceDataHistories { get; set; }
        public DbSet<DeviceDataMap> DeviceDataMaps { get; set; }
        public DbSet<DeviceDataTracking> DeviceDataTrackings { get; set; }
        public DbSet<DeviceDataTrackingHistory> DeviceDataTrackingHistories { get; set; }
        public DbSet<DeviceDataUserMap> DeviceDataUserMaps { get; set; }
        public DbSet<DeviceTrackingDays> DeviceTrackingDays { get; set; }
        public DbSet<DeviceTrackingDaysHistory> DeviceTrackingDaysHistories { get; set; }
        public DbSet<DeviceUserReport> DeviceUserReports { get; set; }
        public DbSet<DeviceUserReportAccount> DeviceUserReportAccounts { get; set; }
        public DbSet<DeviceUserReportMap> DeviceUserReportMaps { get; set; }
        public DbSet<DragAndDrop> DragAndDrops { get; set; }
        public DbSet<EmailAttachment> EmailAttachments { get; set; }
        public DbSet<EmailQueue> EmailQueues { get; set; }
        public DbSet<GraphDragAndDrop> GraphDragAndDrops { get; set; }
        public DbSet<InputBasedCounter> InputBasedCounters { get; set; }
        public DbSet<InputBasedCounterHistory> InputBasedCounterHistories { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<MachineTypeInput> MachineTypeInputs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationHistory> NotificationHistories { get; set; }
        public DbSet<NotificationOld> NotificationOlds { get; set; }
        public DbSet<OrderByDevice> OrderByDevices { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartsHistory> PartsHistories { get; set; }
        public DbSet<PlannedShutdownDescription> PlannedShutdownDescriptions { get; set; }
        public DbSet<PlannedShutdownDescriptionMaster> PlannedShutdownDescriptionMasters { get; set; }
        public DbSet<PushNotificationDevice> PushNotificationDevices { get; set; }
        public DbSet<QuickReportSetting> QuickReportSettings { get; set; }
        public DbSet<RemovedAssignedPart> RemovedAssignedParts { get; set; }
        public DbSet<ReportNotificationType> ReportNotificationTypes { get; set; }
        public DbSet<ReportSettings> ReportSettings { get; set; }
        public DbSet<SchedulerNotes> SchedulerNotes { get; set; }
        public DbSet<SchedulerUpdate> SchedulerUpdates { get; set; }
        public DbSet<Scrap> Scraps { get; set; }
        public DbSet<ScrapHistory> ScrapHistories { get; set; }
        public DbSet<ScrapType> ScrapTypes { get; set; }
        public DbSet<SheduleDescription> SheduleDescriptions { get; set; }
        public DbSet<Sheduler> Shedulers { get; set; }
        public DbSet<Skids> Skids { get; set; }
        public DbSet<SmartAuthentication> SmartAuthentications { get; set; }
        public DbSet<SmartSchedulerPlan> SmartSchedulerPlans { get; set; }
        public DbSet<SmartSchedulerSplitPlan> SmartSchedulerSplitPlans { get; set; }
        public DbSet<TargetPMM> TargetPMMs { get; set; }
        public DbSet<ToolingIds> ToolingIds { get; set; }
        public DbSet<WorkingDays> WorkingDays { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
    }
}
