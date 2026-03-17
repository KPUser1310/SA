using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class ScrapType :BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScrapTypeId { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; } = false;
        public ICollection<NotificationHistory> NotificationHistorys { get; set; }
    }
}
