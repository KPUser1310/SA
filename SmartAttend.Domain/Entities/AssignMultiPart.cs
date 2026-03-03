using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class AssignMultiPart : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignMultiPartId { get; set; }
        public int? AssignPartId { get; set; }
        public int? PartId { get; set; }
        public int? RequiredQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CycleTime { get; set; }
        public int? Cavity { get; set; }
        public long? DeviceId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool? Status { get; set; }
        public int? NoOfSkids { get; set; }
        public bool? IsJobUpdated { get; set; }
        public DateTime? JobUpdatedTime { get; set; }
        public int? QtyPerSkid { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(AssignPartId))]
        public virtual AssignedPart AssignedPart { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
    }
}
