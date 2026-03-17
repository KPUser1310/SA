using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class EmailAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailAttachmentId { get; set; }
        public int EmailQueueId { get; set; }
        public string? EntityType { get; set; }
        public int? EntityId { get; set; } 
        public string AttachmentPath { get; set; } = null!;
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(EmailQueueId))]
        public virtual EmailQueue EmailQueue { get; set; }
    }
}
