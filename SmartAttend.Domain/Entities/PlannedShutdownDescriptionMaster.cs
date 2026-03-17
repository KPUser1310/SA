using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class PlannedShutdownDescriptionMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? EntityType { get; set; }
        public bool IsDelete { get; set; } = false;

        public ICollection<PlannedShutdownDescription> PlannedShutdownDescriptions { get; set; }   
    }
}
