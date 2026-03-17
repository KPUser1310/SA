using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceDataTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long DeviceId { get; set; }
        public string InputName { get; set; } 
        public int? Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? StartDateTime { get; set; } = DateTime.Now;
        public DateTime? EndDateTime { get; set; }
        public double? Duration { get; set; }
        public string Reasoncurrent { get; set; }
        public string Reasonprevious { get; set; }
        public double? Stopduration { get; set; }
        public bool IsManual { get; set; }
        public int? CurrentShutdownMasterId { get; set; }
        public int? PlannedShutdownMasterId { get; set; }
        public int? TotalCycle { get; set; }
        public int? CompletedQuantity { get; set; }
        public double? CycleDuration { get; set; }
        public int? Efficiency { get; set; }
        public string DowntimeReason { get; set; } // nvarchar(max)
        public bool IsDelete { get; set; } = false;
        public DateTime? DtUpdatedTime { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
    }
}
