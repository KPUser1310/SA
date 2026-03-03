using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class SmartSchedulerPlan : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SmartSchedulerId { get; set; }       
        public string? PartNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RequiredQuantity { get; set; }
        public bool IsUpdated { get; set; } = false; 
        public int IsShutdown { get; set; } = 0; 
        public string? ShutdownName { get; set; }
        public int IsUpdatePartNumber { get; set; } = 1; 
        public DateTime? ScheduleMaxDate { get; set; }
        public bool IsSplited { get; set; } = false;
        public int? NotesId { get; set; }
        public long DeviceId { get; set; }

        public bool IsDelete { get; set; } = false;
        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
        public int? PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }
        public ICollection<SmartSchedulerSplitPlan> SmartSchedulerSplitPlans { get; set; }
    }
}
