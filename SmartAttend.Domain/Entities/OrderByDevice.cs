using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class OrderByDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public bool Ascending { get; set; } = false; 
        public bool Descending { get; set; } = false; 
        public bool Customize { get; set; } = true;

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
