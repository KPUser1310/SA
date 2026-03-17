using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class ReportType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportTypeId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsDelete { get; set; } = false;
        public ICollection<DeviceUserReportMap> DeviceUserReportMaps { get; set; }
    }
}
