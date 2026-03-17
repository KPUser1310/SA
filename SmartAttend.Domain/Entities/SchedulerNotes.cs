using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }
    }
}
