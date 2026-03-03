using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class ToolingIds : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToolingId { get; set; }
        public string? ToolingNumber { get; set; } 
        public int PartId { get; set; }
        public int CustomerId { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

    }
}
