using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ForeignKey(nameof(EmailQueueId))]
        public virtual EmailQueue EmailQueue { get; set; }
    }
}
