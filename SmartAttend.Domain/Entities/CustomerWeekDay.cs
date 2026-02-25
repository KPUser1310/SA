using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class CustomerWeekDay : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerWeekDayId { get; set; }
        public int? CustomerId { get; set; }
        public string Days { get; set; }
        public bool? Status { get; set; }
        public bool IsChanges { get; set; } = false;

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}
