using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceDataTrackingHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryID { get; set; }
        public int DeviceDataId { get; set; }  // Reference to devicedata.id
        public long DeviceID { get; set; }
        public string InputName { get; set; } 
        public int? Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Duration { get; set; }
        public string Reasoncurrent { get; set; }
        public string? Reasonprevious { get; set; }
        public double? Stopduration { get; set; }
        public bool IsManual { get; set; }
        public int? CurrentShutdownMasterID { get; set; }
        public int? PlannedShutdownMasterID { get; set; }
        public int? TotalCycle { get; set; }
        public int? CompletedQuantity { get; set; }
        public double? CycleDuration { get; set; }
        public int? Efficiency { get; set; }
        public string? DowntimeReason { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? DtUpdatedTime { get; set; }
        [ForeignKey(nameof(DeviceDataId))]
        public virtual DeviceData DeviceData { get; set; }

        [ForeignKey(nameof(DeviceID))]
        public virtual Device Device { get; set; }
    }
}
