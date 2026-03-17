using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsDelete { get; set; } = false;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }
        public ICollection<DeviceDataUserMap> DeviceDataUserMap { get; set;}
    }
}
