using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class QuickReportSetting : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuickReportSettingId { get; set; }
        public int UserId { get; set; }
        public bool Description { get; set; } = true;
        public bool ProductionHours { get; set; } = true;
        public bool PartsProduced { get; set; } = true;
        public bool AvgCycle { get; set; } = true;
        public bool Target { get; set; } = true;
        public bool NoOfIncidents { get; set; } = true;
        public bool Scrap { get; set; } = true;
        public bool TotalCost { get; set; } = true;
        public bool TotalValue { get; set; } = true;
        public bool CycleEfficiency { get; set; } = true;
        public bool ScrapValue { get; set; } = false;
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(UserId))]
        public virtual Account Account { get; set; }
    }
}
