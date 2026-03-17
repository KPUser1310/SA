namespace SmartAttend.Application.Production.DTOs
{
    public class AddScrapDto
    {
        public int PartID { get; set; }
        public int DeviceId { get; set; }
        public int ScrapCount { get; set; }
        public int ScrapType { get; set; }
        public string? Notes { get; set; }
    }

    public class AddScrapResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}