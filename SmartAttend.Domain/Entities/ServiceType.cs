using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class ServiceType : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        public string ServiceTypeName { get; set; }
        public bool IsDelete { get; set; } = false;
        public ICollection<Customer> Customers { get; set; } 
    }
}
