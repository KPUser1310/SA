using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class CustomerShift : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }
        public int? CustomerId { get; set; }       
        public string ShiftName { get; set; } 
        public string ShiftFrom { get; set; } 
        public string ShiftTo { get; set; }
        public int Days { get; set; } = 0;
        public int? ScheduleDescriptionID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Monday { get; set; } = false;
        public bool? Tuesday { get; set; } = false;
        public bool? Wednesday { get; set; } = false;
        public bool? Thursday { get; set; } = false;
        public bool? Friday { get; set; } = false;
        public bool? Saturday { get; set; } = false;
        public bool? Sunday { get; set; } = false;
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
