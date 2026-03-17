using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class Skids : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PartId { get; set; }
        public long DeviceId { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual Account Account { get; set; }
    }
}
