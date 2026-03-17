using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartAttend.Domain.Entities
{
    public partial class DeviceUserReport 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceUserReportId { get; set; }
        public string? Name { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        public ICollection<DeviceUserReportAccount> DeviceUserReportAccounts { get; set; }

        public ICollection<DeviceUserReportMap> DeviceUserReportMaps { get; set; }

    }
}
