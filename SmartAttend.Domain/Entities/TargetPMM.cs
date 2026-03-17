using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class TargetPMM : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TargetId { get; set; }
        public long? HourlyTarget { get; set; }
        public long? DailyTarget { get; set; }
        public long? MonthlyTarget { get; set; }
        public long? YearlyTarget { get; set; }
        public int? DownTimeTarget { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int? CustomerId { get; set; }
        public string? Shift { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
