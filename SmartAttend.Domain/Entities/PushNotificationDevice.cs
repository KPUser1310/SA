using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class PushNotificationDevice : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string DeviceToken { get; set; } = null!;
        public string DeviceType { get; set; } = null!;
        public bool IsDelete { get; set; } = false;
    }
}
