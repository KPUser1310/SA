using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceDataUserMap
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
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(DeviceDataMapId))]
        public virtual DeviceDataMap DeviceDataMap { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<NotificationOld> NotificationOld { get; set; }
    }
}
