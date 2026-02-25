using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class ServiceType : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string ServiceTypeName { get; set; }
        public ICollection<Customer> Customers { get; set; } 
    }
}
