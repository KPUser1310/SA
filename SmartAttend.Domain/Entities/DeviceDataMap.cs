using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Entities
{
    public partial class DeviceDataMap : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DevicedataMapId { get; set; }
        public long DeviceId { get; set; }
        public string Input { get; set; }
        public string InputName { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
        public ICollection<DeviceDataUserMap> DeviceDataUserMap { get; set;}
    }
}
