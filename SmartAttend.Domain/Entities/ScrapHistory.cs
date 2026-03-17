using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class ScrapHistory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScrapHistoryId { get; set; }
        public int PartId { get; set; }
        public long? DeviceId { get; set; }
        public int ScrapCount { get; set; } = 0; 
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? ScrapReason { get; set; } 
        public string? Notes { get; set; }
        public string? UserName { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }  
    }
}
