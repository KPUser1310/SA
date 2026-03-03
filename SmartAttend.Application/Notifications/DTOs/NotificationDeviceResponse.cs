namespace SmartAttend.Application.Notifications.DTOs
{
    public  class NotificationDeviceResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<NotificationDetails> NotificationDeviceModelDetails { get; set; }

    }
    public class NotificationDetails
    {
        public int Id { get; set; }
        public long DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int? DeviceDataUserMapId { get; set; }
        public string InputName { get; set; }
        public int Notifycount { get; set; }
        public int DeviceNotifycount { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
    }
}
