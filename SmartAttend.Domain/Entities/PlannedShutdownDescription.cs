using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class PlannedShutdownDescription : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? PlannedShutdownMasterId { get; set; }
        public long? DeviceId { get; set; }
        public int? EntityType { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }

        [ForeignKey(nameof(PlannedShutdownMasterId))]
        public virtual PlannedShutdownDescriptionMaster PlannedShutdownDescriptionMaster { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
    }
}
