using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Devices.Queries.GetDevices
{
    public class GetDevicesQuery : IRequest<List<DeviceListDto>>
    {
        public int customerId { get; set; }
    }
}
