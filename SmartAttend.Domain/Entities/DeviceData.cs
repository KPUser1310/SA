using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long DeviceId { get; set; }      
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
        public bool IsTrackingDay { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
        public ICollection<DeviceDataHistory> DeviceDataHistorys { get; set; }
        public ICollection<DeviceDataTrackingHistory> DeviceDataTrackingHistorys { get; set; }

    }
}
