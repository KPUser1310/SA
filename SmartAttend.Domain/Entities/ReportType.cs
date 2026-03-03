using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
