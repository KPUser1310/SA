using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class Sheduler : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShedulerId { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
