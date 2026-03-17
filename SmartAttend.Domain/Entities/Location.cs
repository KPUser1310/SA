using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual Customer Customer { get; set; }
    }
}
