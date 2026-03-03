
namespace SmartAttend.Application.Notifications.DTOs
{
    public class NotificationRequest
    {
        public int AccountId { get; set; } = 0;

        public long DeviceId { get; set; } = 0;

        public int PageNo { get; set; } = 1;

        public int Size { get; set; } = 25;

        public string FromDate { get; set; } = null;

        public string ToDate { get; set; } = null;

        public int Read { get; set; } = 2;

        public int Search { get; set; } = 0;
    }
}