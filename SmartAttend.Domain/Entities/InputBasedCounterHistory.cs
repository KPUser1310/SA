using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class InputBasedCounterHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        public int? AssignedPartId { get; set; } 
        public long? DeviceId { get; set; }   
        public string? Input { get; set; }      
        public string? Description { get; set; }   
        public int? Counter { get; set; }    
        public long? DefaultTime { get; set; }    
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AssignedPartId))]
        public virtual AssignedPart AssignedPart { get; set; }
    }
}
