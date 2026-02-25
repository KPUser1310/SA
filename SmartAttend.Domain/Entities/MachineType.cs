using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class MachineType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }
        public string MachineTypeName { get; set; }
        public int?  CustomerId { get; set; }
        public string WLAN_SSId { get; set; }
        public string WLAN_Password { get; set; }
        public bool? Pulse_Freq { get; set; }
        public int? IsUpdated { get; set; }
        public string FTP_UserName { get; set; }
        public string FTP_Password { get; set; }
        public bool? Firm_Update_Required { get; set; }
        public string Pulse_Values { get; set; }
        public string ServerIPFirst { get; set; }
        public string ServerIPSecond { get; set; }
        public string PortFirst { get; set; }
        public string PortSecond { get; set; }
        public string HostName { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        public ICollection<DeviceConfig> DeviceConfigs { get; set; }
        public ICollection<MachineTypeInput> MachineTypeInputs { get; set; }
    }
}
