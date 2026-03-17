using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAttend.Domain.Entities
{
    public partial class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long? DeviceId { get; set; }     
        public int AccountId { get; set; }
        public int? DeviceDataUserMapId { get; set; } 
        public string InputName { get; set; }
        public string? Message { get; set; }    
        public string? CustomMessage { get; set; }
        public string? ContactFromHours { get; set; }
        public string? ContactToHours { get; set; }
        public int? Reminder { get; set; }
        public DateTime? SentDate { get; set; }
        public bool IsNotify { get; set; }
        public bool IsDelete { get; set; } = false;
        public int? EntityType { get; set; } = 1;     
        public string? CompletedReason { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int RowNumber { get; set; } = 0;

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(DeviceDataUserMapId))]
        public virtual DeviceDataUserMap DeviceDataUserMap { get; set; }
    }
}
