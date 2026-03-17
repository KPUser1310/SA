using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class ReportNotificationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportNotificationTypeId { get; set; }    
        public string Description { get; set; }
        public bool IsDelete { get; set; } = false;
        public ICollection<DeviceUserReportMap> DeviceUserReportMaps { get; set; }
    }
}
