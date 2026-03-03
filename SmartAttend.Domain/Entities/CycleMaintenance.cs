using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Domain.Entities
{
    public class CycleMaintenance : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CycleMaintenanceId { get; set; }
        public long DeviceId { get; set; }
        public int PartId { get; set; }
        public int? MachineTypeId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaintenanceCount { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        public ICollection<CycleUserMap> CycleUserMaps { get; set; }

    }
}
