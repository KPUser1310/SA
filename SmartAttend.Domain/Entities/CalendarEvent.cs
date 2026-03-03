using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class CalendarEvent : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CalendarEventId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public ICollection<CalendarShiftTime> CalendarShiftTimes { get; set; }
    }
}
