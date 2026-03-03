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
    public partial class DeviceTrackingDays
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public long DeviceId { get; set; }
        public int? PartId { get; set; }
        public string? PartNumber { get; set; }
        public string InputName { get; set; } 
        public int? Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Duration { get; set; }
        public string Reasoncurrent { get; set; }
        public string Reasonprevious { get; set; }
        public int? CurrentShutdownMasterID { get; set; }
        public int? PlannedShutdownMasterID { get; set; }
        public double? Stopduration { get; set; }
        public bool IsManual { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }
        public ICollection<DeviceTrackingDaysHistory> DeviceTrackingDaysHistorys { get; set; }
    }
}
