using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class ReportSettings : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportSettingId { get; set; }
        public int? UserId { get; set; }
        public bool? QuickReport { get; set; } = false;
        public bool? PartReport { get; set; } = false;
        public bool? ScrapReport { get; set; } = false;
        public bool? TrackingReport { get; set; } = false;
        public bool? PartProducedReport { get; set; } = false;
        public bool? CycleReport { get; set; } = false;
        public bool? OverallReport { get; set; } = false;
        public bool? DowntimeReasonReport { get; set; } = false;
        public bool? DetailedDowntimeReport { get; set; } = false;
        public bool? ProductionReportM2 { get; set; } = false;
        public bool? ProductionDetailReport { get; set; } = false;
        public bool? DailyRevenueReport { get; set; } = false;
        public bool? MonthlyRevenueReport { get; set; } = false;
        public bool? ProductionReport { get; set; } = false;
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(UserId))]
        public virtual Account Account { get; set; }
    }
}
