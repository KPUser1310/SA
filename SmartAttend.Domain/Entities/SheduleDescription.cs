using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class SheduleDescription : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleDescriptionId { get; set; }
        public string? Description { get; set; }
        public string? CustomerIDs { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
