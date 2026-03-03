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
    public partial class DeviceDataHistory 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        public int DeviceDataId { get; set; }  // Reference to devicedata.id
        public long DeviceID { get; set; }
        public string Time { get; set; } 
        public string Date { get; set; } 
        public DateTime? DateTime { get; set; }
        public int Priority { get; set; }
        public int PowerOn { get; set; }
        public int Ping { get; set; }
        public int Offline { get; set; }
        public int Counter { get; set; }
        public int Input1 { get; set; }
        public int Input2 { get; set; }
        public int Input3 { get; set; }
        public int Input4 { get; set; }
        public int Input5 { get; set; }
        public int Input6 { get; set; }
        public int Input7 { get; set; }
        public int Input8 { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? CheckDate { get; set; }
        public int Scrap { get; set; }
        public int GrossQty { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceDataId))]
        public virtual DeviceData DeviceData { get; set; }

        [ForeignKey(nameof(DeviceID))]
        public virtual Device Device { get; set; }
    }
}
