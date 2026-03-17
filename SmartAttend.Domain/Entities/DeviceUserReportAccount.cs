using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceUserReportAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceUserReportAccountId { get; set; }
        public int DeviceUserReportId { get; set; } // Reference to DeviceUserReport.DeviceUserReportID
        public int AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDae { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceUserReportId))]
        public virtual DeviceUserReport DeviceUserReport { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
