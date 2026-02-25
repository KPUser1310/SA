using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class SmartAuthentication : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? AuthId { get; set; }
        public int? AccountId { get; set; }
        public string? AuthToken { get; set; }
        public int? ExpirtDays { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
