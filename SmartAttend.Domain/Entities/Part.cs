using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class Part : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartId { get; set; }
        public string GroupID { get; set; }
        public string PartNumber { get; set; }
        public int? Cavity { get; set; }
        public decimal? CycleTime { get; set; }
        public string Description { get; set; }
        public decimal? PartPrice { get; set; }
        public bool Status { get; set; } = true;
        public int? QtyPerSkid { get; set; } = 0;
        public decimal? ScrapPrice { get; set; }
        public int? CustomerId { get; set; }
        public bool IsDelete { get; set; } = false;
        public int? LocationId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }

        public ICollection<PartsHistory> PartsHistorys { get; set; }
        public ICollection<AssignedPart> AssignedParts { get; set; }
        public ICollection<AssignedPartsHistory> AssignedPartsHistorys { get; set; }
        public ICollection<AssignMultiPart> AssignMultiParts { get; set; }
        public ICollection<CycleMaintenance> CycleMaintenances { get; set; }

        public ICollection<DeviceTrackingDays> DeviceTrackingDays { get; set; }
        public ICollection<DeviceTrackingDaysHistory> DeviceTrackingDaysHistorys { get; set; }
        public ICollection<RemovedAssignedPart> RemovedAssignedParts { get; set; }
        public ICollection<SchedulerNotes> SchedulerNotes { get; set; }
        public ICollection<Scrap> Scraps { get; set; }
        public ICollection<ScrapHistory> ScrapHistories { get; set; }
        public ICollection<Skids> Skids { get; set; }
        public ICollection<SmartSchedulerPlan> SmartSchedulerPlans { get; set; }
        public ICollection<SmartSchedulerSplitPlan> SmartSchedulerSplitPlans { get; set; }
        public ICollection<ToolingIds> ToolingIds { get; set; }
    }
}
