using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class InputBasedCounter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? AssignedPartId { get; set; }
        public long? DeviceId { get; set; }    
        public string? Input { get; set; }    
        public string? Description { get; set; }   
        public int? Counter { get; set; }  
        public long? DefaultTime { get; set; }    
        public bool? IsProcessed { get; set; }   
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AssignedPartId))]
        public virtual AssignedPart AssignedPart { get; set; }
    }
}
