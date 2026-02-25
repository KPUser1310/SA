using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class CalendarShiftTime : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CalendarShiftTimeId { get; set; }
        public int CalendarEventId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Type { get; set; }
        public int? ScheduleDescriptionId { get; set; }
        public int? ShiftId { get; set; }
        public int IsApplied { get; set; } = 0;
        public bool? IsResetPartDate { get; set; } = false;
       
        [ForeignKey(nameof(CalendarEventId))]
        public virtual CalendarEvent CalendarEvent { get; set; }
    }
}
