using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SmartAttend.Domain.Entities
{
    public partial class CustomerSetting : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public bool IsGrossQuantity { get; set; } = false;
        public int MachineType { get; set; } = 2;
        public bool IsDownTimeDuration { get; set; } = true;
        public bool IsResolvedNotification { get; set; } = true;
        public bool IsCycletimeMilliSeconds { get; set; } = false;
        public bool CheckMachineType { get; set; } = true;
        public int CycleTolerance { get; set; } = 5;
        public int? DowntimeTolerance { get; set; } = 5;
        public int MachineTargetPMM { get; set; } = 400;
        public bool DowntimeCount { get; set; } = false;
        public bool EnableCavity { get; set; } = false;
        public bool Drift { get; set; } = true;
        public bool Scheduler { get; set; } = false;
        public bool DashboardBlink { get; set; } = false;
        public bool ThousandSeperator { get; set; } = false;
        public bool LastCounterCycleTime { get; set; } = false;
        public bool ResetAssingnedPartDate { get; set; } = false;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
