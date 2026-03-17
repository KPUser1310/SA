namespace SmartAttend.Application.Machine.DTOs
{
    public class CreateMachineRequest
    {    
        public long Id { get; set; }       
        public long DeviceId { get; set; }    //  DeviceSerialNumber
        public string DeviceName { get; set; }    
        public string Size { get; set; }
        public decimal? PressRate { get; set; }
        public int? MachineId { get; set; }
        public string PartNumber { get; set; }
     
    }

    public class DeviceDataMapRequest
    {
       // public int DeviceDataMapId { get; set; }
        public string Input { get; set; }
        public string InputName { get; set; }
       
    }
       
}