using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class RemovedAssignedPart : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RemoveId { get; set; }
        public int? PartId { get; set; }
        public long? DeviceId { get; set; }
        public int? Cavity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CycleTime { get; set; }
        public int? RequiredQuantity { get; set; }
        public int? CompletedQuantity { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? RunningDuration { get; set; }
        public string? ETA { get; set; }
        public int? Scrap { get; set; }
        public int? CurrentScrap { get; set; }
        public string? CalculatedCycleTime { get; set; }
        public bool? Status { get; set; }
        public DateTime? AssignedPartDate { get; set; }
        public int? Efficiency { get; set; }
        public int? QtyPercentage { get; set; }
        public int? DownTimeDurationId { get; set; }
        public string? DowntimeDuration { get; set; }
        public int? DownTimePercentage { get; set; }
        public int GrossQty { get; set; } = 0;
        public int? BackupData { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }


        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
    }
}
