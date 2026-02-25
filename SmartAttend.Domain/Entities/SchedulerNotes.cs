using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace SmartAttend.Domain.Entities
{
    public partial class SchedulerNotes : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotesId { get; set; }
        public long? DeviceId { get; set; }
        public int? PartId { get; set; }
        public string? Notes { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsActive { get; set; } = true;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }
    }
}
