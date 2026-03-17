using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SmartAttend.Application.Devices.Queries.SaveDeviceConfiguration
{
    public class SaveDeviceConfigurationCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [Required]
        public string DeviceName { get; set; }

        [Required]
        public int MachineTypeId { get; set; }

        public decimal? PressRate { get; set; }

        public string? Size { get; set; }

        public IFormFile? Image { get; set; }
    }
}