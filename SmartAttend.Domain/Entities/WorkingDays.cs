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
    public partial class WorkingDays : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkDaysId { get; set; }
        public int? AccountId { get; set; }
        public string? Days { get; set; }
        public bool IsSelected { get; set; } = false;
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

    }
}
