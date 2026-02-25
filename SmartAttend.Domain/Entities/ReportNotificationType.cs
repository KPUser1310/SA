using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class ReportNotificationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportNotificationTypeId { get; set; }    
        public string Description { get; set; }   
        public bool IsActive { get; set; }
        public ICollection<DeviceUserReportMap> DeviceUserReportMaps { get; set; }
    }
}
