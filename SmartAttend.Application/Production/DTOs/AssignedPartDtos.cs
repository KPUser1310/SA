namespace SmartAttend.Application.Production.DTOs
{
    public class AssignedPartsDtos
    {
        public int Id { get; set; }
        public long DeviceId { get; set; }
        public int? PartId { get; set; }
        public string PartNumber { get; set; }
        public string MachineName { get; set; }
        public int? Cavity { get; set; }
        public decimal? CycleTime { get; set; }
        public int? Scrap { get; set; }
        public string StartDateTime { get; set; }
        public int? RequiredQuantity { get; set; }

    }
}