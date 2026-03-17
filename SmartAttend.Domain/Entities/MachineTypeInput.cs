using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class MachineTypeInput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MachineTypeId { get; set; }
        public int InputNo { get; set; }        
        public string Name { get; set; } 
        public string Priority { get; set; } 
        public string Color { get; set; }
        public string FlashSpeed { get; set; } 
        public string Sound { get; set; } 
        public string Delay { get; set; }
        public bool IsDelete { get; set; } = false;


        [ForeignKey(nameof(MachineTypeId))]
        public virtual MachineType MachineType { get; set; }
    }
}
