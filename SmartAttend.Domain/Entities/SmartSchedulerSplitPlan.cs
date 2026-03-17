using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class SmartSchedulerSplitPlan : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SmartSchedulerSplitId { get; set; }
        public int SmartSchedulerId { get; set; }
        public long DeviceId { get; set; }
        public int? PartId { get; set; }
        public string? PartNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RequiredQuantity { get; set; }
        public bool IsUpdated { get; set; } = false; 
        public int IsShutdown { get; set; } = 0; 
        public string? ShutdownName { get; set; }
        public int IsUpdatePartNumber { get; set; } = 1; 
        public DateTime? ScheduleMaxDate { get; set; }
        public bool IsSplited { get; set; } = false; 
        public int? NotesId { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
        [ForeignKey(nameof(SmartSchedulerId))]
        public virtual SmartSchedulerPlan SmartSchedulerPlan { get; set; }
    }
}
