using System;

namespace SmartAttend.Application.Parts.DTOs
{
    public class UpdateAssignedPartDtos
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public string PartNumber { get; set; }
        public string MachineName { get; set; }
        public int DeviceId { get; set; }
        public int? Cavity { get; set; }
        public decimal? CycleTime { get; set; }
        public int? RequiredQuantity { get; set; }
        public int? CurrentScrap { get; set; }
        public int? Scrap { get; set; }
        public int? GrossQty { get; set; }
    }
}
