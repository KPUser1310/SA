using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Common.Constant;

namespace SmartAttend.Application.Devices.Queries.GetDeviceConfiguration
{
    public class GetDeviceConfigurationQueryHandler
        : IRequestHandler<GetDeviceConfigurationQuery, DeviceConfigurationDto>
    {
        private readonly IApplicationDbContext _context;

        public GetDeviceConfigurationQueryHandler(
            IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeviceConfigurationDto> Handle(GetDeviceConfigurationQuery request, CancellationToken cancellationToken)
        {
            var deviceData = await (
                from d in _context.Devices.AsNoTracking()
                join machine in _context.MachineTypes.AsNoTracking()
                    on d.MachineID equals machine.MachineId into machineJoin
                from machine in machineJoin.DefaultIfEmpty()
                where d.Id == request.Id
                select new
                {
                    d.Id,
                    d.DeviceId,
                    d.DeviceName,
                    d.Size,
                    d.PressRate,
                    d.Image,
                    MachineTypeName = machine.MachineTypeName
                }
            ).FirstOrDefaultAsync(cancellationToken);

            if (deviceData == null)
            {
                return null;
            }

            var device = new DeviceConfigurationDto
            {
                Id = deviceData.Id,
                DeviceId = deviceData.DeviceId,
                DeviceName = deviceData.DeviceName,
                machineTypeName = deviceData.MachineTypeName ?? string.Empty,
                Size = deviceData.Size,
                PressRate = deviceData.PressRate,
                Image = GetDeviceImageUrl($"{deviceData.Id}_{deviceData.Image}")
            };

            var inputs = await (
                from map in _context.DeviceDataMaps.AsNoTracking()
                join user in _context.DeviceDataUserMaps.AsNoTracking()
                    on map.DevicedataMapId equals user.DeviceDataMapId into userJoin
                from user in userJoin.DefaultIfEmpty()
                where map.DeviceId == request.Id && !map.IsDelete
                orderby map.Input
                select new DeviceConfigurationInputDto
                {
                    InputId = map.DevicedataMapId,
                    Input = map.Input,
                    InputName = map.InputName,
                    DeviceUserMapId = user.DeviceDataUserMapId,
                    Contact = user.Contact,
                    ContactHourFrom = user.ContactHourFrom,
                    ContactHourTo = user.ContactHourTo,
                    TimeDelay = user.TimeDelay,
                    Reminder = user.Remainder,
                    Message = user.Message
                }
            ).ToListAsync(cancellationToken);

            device.Inputs = inputs;

            return device;
        }

        private string GetDeviceImageUrl(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            return $"{Constant.MachineImageUrl}/{fileName}";
        }
    }
}