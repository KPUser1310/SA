using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class ScrapType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScrapTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true; 
        public DateTime? CreatedDate { get; set; }

        public ICollection<NotificationHistory> NotificationHistorys { get; set; }
    }
}
