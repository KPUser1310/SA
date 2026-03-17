using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceConfig : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DeviceConfigId { get; set; }
        public long DeviceId { get; set; }
        public int? MachineId { get; set; }
        public string WLAN_SSID { get; set; }
        public string WLAN_Password { get; set; }
        public string Pulse_Values { get; set; }
        public bool? Pulse_Freq { get; set; }
        public int IsUpdated { get; set; } = 0;
        public string FTP_UserName { get; set; }
        public string FTP_Password { get; set; }
        public string ServerIPFirst { get; set; }
        public string ServerIPSecond { get; set; }
        public string PortFirst { get; set; }
        public string PortSecond { get; set; }
        public string ConfigPortOne { get; set; }
        public string ConfigPortTwo { get; set; }
        public string HostName { get; set; }
        public string FtpFolder { get; set; }
        public string ConfigIp1Address { get; set; }
        public string ConfigIp2Address { get; set; }
        public bool Firm_Update_Required { get; set; }
        public string? ClientIPAddress { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeviceUpdatedDate { get; set; }
        public string ErrorLog { get; set; } 
        public string FirmwareUpdateNo { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(MachineId))]
        public virtual MachineType MachineType { get; set; }
        public ICollection<DeviceConfigDetails> DeviceConfigDetails { get; set; }
    }
}
