using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Devices.Queries.GetDeviceConfiguration
{
    public class GetDeviceConfigurationQuery : IRequest<DeviceConfigurationDto>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
    }
}
