using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class OrderByDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public bool Ascending { get; set; } = false; 
        public bool Descending { get; set; } = false; 
        public bool Customize { get; set; } = true;
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
