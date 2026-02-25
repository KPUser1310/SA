namespace SmartAttend.Application.Common.DTOs
{
    public partial class PageResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
