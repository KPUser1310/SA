using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace SmartAttend.Domain.Entities
{
    public partial class DragAndDrop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DragDropId { get; set; }
        public int AccountId { get; set; }
        [Column("X-Postion")]
        public int? XPostion { get; set; } 
        [Column("Y-Postion")]
        public int? YPostion { get; set; }  
        public int? ShowId { get; set; }    
        public long? DeviceId { get; set; } 
        public bool IsActive { get; set; } = false; 
        public bool DoubleClick { get; set; } = false; 
        public string? DeviceName { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
