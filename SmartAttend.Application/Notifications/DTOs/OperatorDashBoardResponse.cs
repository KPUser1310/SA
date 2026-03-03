namespace SmartAttend.Application.Notifications
{

    public class OperatorDashBoardResponse
    {
        public int NotificationId { get; set; }
        public long DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string InputName { get; set; }
        public int RunningStatus { get; set; }
        public int Alarm { get; set; }
        public string Description { get; set; }
        public int? InputId { get; set; }
        public int AccountId { get; set; }
        public int IsShutdown { get; set; }
        public string CreatedDate { get; set; }
    }

    public class DeviceDataUserMaps
    {
        public int DeviceDataUserMapId { get; set; }
        public int IsShutdown { get; set; }
    }
}
