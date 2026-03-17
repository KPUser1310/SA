using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class SchedulerUpdate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchedulerUpdateId { get; set; }
        public int? CustomerId { get; set; }
        public int? AccountId { get; set; }
        public bool IsSchedulerUpdate { get; set; }
        public bool IsChanges { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
