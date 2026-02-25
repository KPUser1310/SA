using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public class CycleNotification : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long? DeviceId { get; set; }
        public int AccountId { get; set; }
        public string Message { get; set; }
        public string CustomMessage { get; set; }
        public int? Reminder { get; set; }
        public DateTime? SentDate { get; set; }
        public bool? IsNotify { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
