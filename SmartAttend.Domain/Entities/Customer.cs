using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class Customer : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Customer_Id { get; set; }
        public string CompanyName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string ContactNo { get; set; }
        public string Website { get; set; }

        [Column("ServiceId")]
        public int ServiceId { get; set; }
        public bool? Status { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string CustomerImage { get; set; }
        public bool? IsDelete { get; set; }
        public int? TimeOffset { get; set; }
        public string TimeZone { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual ServiceType ServiceTypes { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
        public ICollection<CustomerSetting> CustomerSettings { get; set; }
        public ICollection<CustomerShift> CustomerShifts { get; set; }
        public ICollection<CustomerWeekDay> CustomerWeekDays { get; set; }
        public ICollection<CycleMaintenance> CycleMaintenances { get; set; }
        public ICollection<DeviceUserReport> DeviceUserReports { get; set; }
        public ICollection<MachineType> MachineTypes { get; set; }
        public ICollection<TargetPMM> TargetPMms { get; set; }
        public ICollection<ToolingIds> ToolingIds { get; set; }
    }
}
