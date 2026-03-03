using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class GraphDragAndDrop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GraphDragDropId { get; set; }
        public int AccountId { get; set; }
        [Column("X-Position")]
        public int? XPosition { get; set; }  
        [Column("Y-Position")]
        public int? YPosition { get; set; } 
        public int? ShowId { get; set; }
        public long? DeviceId { get; set; }   
        public bool IsActive { get; set; }
        public int? GraphId { get; set; }  
        public string? GraphName { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
