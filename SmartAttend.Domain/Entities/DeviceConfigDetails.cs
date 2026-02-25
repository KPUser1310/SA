using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceConfigDetails 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DeviceConfigDetailsId { get; set; }
        public long?  DeviceConfigId { get; set; }
        public string Input_No { get; set; }
        public string Priority { get; set; }
        public string Color { get; set; }
        public string Flash_Speed { get; set; }
        public string Sound { get; set; }
        public string Delay { get; set; }

        // Default values from SQL constraints
        public bool ChangeOver { get; set; } = false;
        public bool Scrap { get; set; } = false;
        public string HexColor { get; set; }
        public string OFFDelay { get; set; }
        public bool Backtrack { get; set; } = false;
        public bool ChangeOverButton { get; set; } = false;
        public bool DowntimeIncident { get; set; } = false;
        public bool ScrapFullCycle { get; set; } = false;
        public bool InputPartReset { get; set; } = false;
        public long? DefaultTime { get; set; }


        [ForeignKey(nameof(DeviceConfigId))]
        public virtual DeviceConfig DeviceConfig { get; set; }
    }
}
