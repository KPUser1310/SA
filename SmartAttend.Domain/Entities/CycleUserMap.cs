using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class CycleUserMap : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CycleUserMapId { get; set; }
        public int CycleMaintenanceId { get; set; }
        public int UserId { get; set; }
        public int? ReportValueTypeId { get; set; }
        public int? ReportValue { get; set; }
        public string? Message { get; set; }
        public int? Remainder { get; set; }
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(CycleMaintenanceId))]
        public virtual CycleMaintenance CycleMaintenance { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Account Account { get; set; }
    }
}
