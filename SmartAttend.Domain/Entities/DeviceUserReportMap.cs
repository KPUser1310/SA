using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceUserReportMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DeviceUserReportId { get; set; } 
        public int AccountId { get; set; }
        public long DeviceId { get; set; }
        public int ReportTypeId { get; set; }
        public int ReportNotificationTypeId { get; set; }
        public int? ReportValueTypeId { get; set; } 
        public string? Value { get; set; }
        public string Message { get; set; } 
        public string? ContactHourFrom { get; set; }
        public string? ContactHourTo { get; set; }
        public string? ReceiveAt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; } = true; // Default true
        public int ReportFormat { get; set; } = 1; // Default 1

        [ForeignKey(nameof(DeviceUserReportId))]
        public virtual DeviceUserReport DeviceUserReport { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(ReportTypeId))]
        public virtual ReportType ReportType { get; set; }

        [ForeignKey(nameof(ReportNotificationTypeId))]
        public virtual ReportNotificationType ReportNotificationType { get; set; }

        [ForeignKey(nameof(ReportValueTypeId))]
        public virtual ReportValueType ReportValueType { get; set; }
    }
}
