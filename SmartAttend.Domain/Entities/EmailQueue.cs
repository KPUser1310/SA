using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class EmailQueue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailQueueId { get; set; }
        public int? AccountId { get; set; } 
        public long? DeviceId { get; set; } 
        public string? ReasonName { get; set; } 
        public string FromEmail { get; set; } = null!; 
        public string ToEmail { get; set; } = null!; 
        public string? Subject { get; set; } 
        public string? Body { get; set; } 
        public bool? IsSend { get; set; } 
        public bool IsAttachment { get; set; } = false; 
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        public ICollection<EmailAttachment> EmailAttachments { get; set; }
    }
}
