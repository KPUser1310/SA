using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class PlannedShutdownDescriptionMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Description { get; set; }
        public int? EntityType { get; set; }
        public bool? Active { get; set; } = true;

        public ICollection<PlannedShutdownDescription> PlannedShutdownDescriptions { get; set; }   
    }
}
