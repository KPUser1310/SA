namespace SmartAttend.Application.Devices.Queries.GetDeviceConfiguration
{
    public class DeviceConfigurationDto
    {
        public long Id { get; set; }          // Primary Key

        public long DeviceId { get; set; }    //  DeviceSerialNumber

        public string DeviceName { get; set; }

        public string machineTypeName { get; set; }

        public string Size { get; set; }

        public decimal? PressRate { get; set; }

        public string Image { get; set; }

        public List<DeviceConfigurationInputDto> Inputs { get; set; }
    }

    public class DeviceConfigurationInputDto
    {
        public long InputId { get; set; }
        public string Input { get; set; }
        public string InputName { get; set; }
        public long DeviceUserMapId { get; set; }
        public int? Contact { get; set; }
        public string ContactHourFrom { get; set; }
        public string ContactHourTo { get; set; }
        public int? TimeDelay { get; set; }
        public int? Reminder { get; set; }
        public string Message { get; set; }
    }
}