using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Reflection.PortableExecutable;

namespace SmartAttend.Domain.Entities
{
    public partial class NotificationHistory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public long DeviceId { get; set; }
        public int ContactId { get; set; }
        public string InputName { get; set; }
        public int ReasonId { get; set; }
        public string Reason { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(ContactId))]
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(ContactId))]
        public virtual ScrapType ScrapType { get; set; }

    }
}
