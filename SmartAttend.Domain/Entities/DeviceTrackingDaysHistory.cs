using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceTrackingDaysHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        public int DeviceTrackingDaysId { get; set; } 
        public long DeviceId { get; set; }
        public int? PartId { get; set; }
        public string PartNumber { get; set; }
        public string InputName { get; set; }
        public int? Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Duration { get; set; }
        public string Reasoncurrent { get; set; }
        public string Reasonprevious { get; set; }
        public int? CurrentShutdownMasterID { get; set; }
        public int? PlannedShutdownMasterID { get; set; }
        public double? StopDuration { get; set; }
        public bool IsManual { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(DeviceTrackingDaysId))]
        public virtual DeviceTrackingDays DeviceTrackingDays { get; set; }
    }
}
