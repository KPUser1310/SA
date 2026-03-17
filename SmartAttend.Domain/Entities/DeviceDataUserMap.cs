using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceDataUserMap : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceDataUserMapId { get; set; }
        public int? DeviceDataMapId { get; set; }
        public int? Contact { get; set; }
        public string? ContactHourFrom { get; set; }
        public string? ContactHourTo { get; set; }
        public int? TimeDelay { get; set; }
        public int? Remainder { get; set; }
        public int IsNotification { get; set; }
        public string? Message { get; set; }    
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceDataMapId))]
        public virtual DeviceDataMap DeviceDataMap { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<NotificationOld> NotificationOld { get; set; }
    }
}
