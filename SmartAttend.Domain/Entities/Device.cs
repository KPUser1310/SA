using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class Device  : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }      
        public long DeviceId { get; set; }
        public int CustomerId { get; set; }
        public string DeviceName { get; set; }
        public int? MachineID { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public bool? Input7Active { get; set; } = true;
        public int? MachineTime { get; set; }
        public bool? Running { get; set; } = false;
        public bool? Alarm { get; set; } = false;
        public bool? IsCommunicating { get; set; } = false;
        public int? IsPlanned { get; set; }
        public bool IsActive { get; set; }
        public bool? IsEmailNotification { get; set; } = false;
        public string TimeZone { get; set; }
        public int? OffsetDifference { get; set; } = 0;
        public bool IsOffSet { get; set; } = false;
        public bool? IsMachineType { get; set; } = false;
        public bool IsMassShutdown { get; set; } = false;
        public bool IsCycleTimeRequiredToShow { get; set; } = true;
        public int Incidents { get; set; } = 0;
        public string PartNumber { get; set; }
        public string CalculatedCycleTime { get; set; }
        public int? CompletedQuantity { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string ETA { get; set; }
        public int? Efficiency { get; set; }
        public string RunningDuration { get; set; }
        public int? QtyPercentage { get; set; }
        public int? DescriptionId { get; set; }
        public string Description { get; set; }
        public int IsChangeOver { get; set; } = 0;
        public string ChangeOverClr { get; set; }
        public int? DowntimeDurationID { get; set; }
        public string DowntimeDuration { get; set; }
        public int? DowntimePercentage { get; set; }
        public DateTime? SinglePlannedDate { get; set; }
        public DateTime? MassPlannedDate { get; set; }
        public DateTime? DownTimeDate { get; set; }
        public DateTime? ScheduleMaxDate { get; set; }
        public bool IsScheduled { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PressRate { get; set; }
        public bool ShowCheck { get; set; } = false;
        public string LastCounterCycleTime { get; set; }
        public int? LastCounterEfficiency { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public ICollection<AssignedPart> AssignedParts { get; set; }
        public ICollection<AssignedPartsHistory> AssignedPartsHistorys { get; set; }
        public ICollection<AssignMultiPart> AssignMultiParts { get; set; }
        public ICollection<CycleMaintenance> CycleMaintenances { get; set; }
        public ICollection<CycleNotification> CycleNotifications { get; set; }
        public ICollection<DeviceConfig> DeviceConfigs { get; set; }
        public ICollection<DeviceData> DeviceDatas { get; set; }
        public ICollection<DeviceDataHistory> DeviceDataHistorys { get; set; }
        public ICollection<DeviceDataMap> DeviceDataMaps { get; set; }
        public ICollection<DeviceDataTracking> DeviceDataTrackings { get; set; }
        public ICollection<DeviceDataTrackingHistory> DeviceDataTrackingHistorys { get; set; }
        public ICollection<DeviceTrackingDays> DeviceTrackingDays { get; set; }
        public ICollection<DeviceTrackingDaysHistory> DeviceTrackingDaysHistory { get; set; }
        public ICollection<DeviceUserReportMap> DeviceUserReportMaps { get; set; }
        public ICollection<DragAndDrop> DragAndDrops { get; set; }
        public ICollection<EmailQueue> EmailQueues { get; set; }
        public ICollection<GraphDragAndDrop> GraphDragAndDrops { get; set; }
        public ICollection<InputBasedCounter> InputBasedCounters { get; set; }
        public ICollection<InputBasedCounterHistory> InputBasedCounterHistorys { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<NotificationOld> NotificationOlds { get; set; }
        public ICollection<NotificationHistory> NotificationHistorys { get; set; }
        public ICollection<PlannedShutdownDescription> PlannedShutdownDescriptions { get; set; }
        public ICollection<SchedulerNotes> SchedulerNotes { get; set; }
        public ICollection<SchedulerUpdate> SchedulerUpdates { get; set; }
        public ICollection<Scrap> Scraps { get; set; }
        public ICollection<ScrapHistory> ScrapHistories { get; set; }
        public ICollection<Skids> Skids { get; set; }
        public ICollection<SmartSchedulerPlan> SmartSchedulerPlans { get; set; }
        public ICollection<SmartSchedulerSplitPlan> SmartSchedulerSplitPlans { get; set; }
    }
}
