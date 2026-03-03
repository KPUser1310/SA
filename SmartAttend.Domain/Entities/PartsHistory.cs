using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class PartsHistory :  BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartsHistoryId { get; set; }
        public int PartId { get; set; }
        public string GroupId { get; set; }
        public string PartNumber { get; set; }
        public int? Cavity { get; set; }
        public bool IsDelete { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CycleTime { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PartPrice { get; set; }
        public int? QtyPerSkid { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ScrapPrice { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }
    }
}
