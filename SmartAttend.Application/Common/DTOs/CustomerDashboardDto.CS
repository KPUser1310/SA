using System.Collections.Generic;

namespace SmartAttend.Application.Common.DTOs
{
    public class CustomerDashboardDto
    {
        public int CustomerId { get; set; }
        public IReadOnlyList<DeviceDto> Machines { get; set; }
            = new List<DeviceDto>();
    }
}
