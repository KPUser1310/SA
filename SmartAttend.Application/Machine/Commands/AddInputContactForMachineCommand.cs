using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Machine.Commands
{
    public class AddInputContactForMachineCommand : IRequest<bool>
    {
        public long DeviceId { get; set; }
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
    public class AddInputContactForMachineCommandHandler : IRequestHandler<AddInputContactForMachineCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        private readonly ICurrentUserService _currentUserService;

        public AddInputContactForMachineCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<bool> Handle(AddInputContactForMachineCommand request, CancellationToken cancellationToken)
        {
            var inputDeviceMaps = await _context.DeviceDataMaps
                .Where(x => x.DevicedataMapId == request.InputId && x.DeviceId == request.DeviceId &&
                    !x.IsDelete).FirstOrDefaultAsync(cancellationToken);

            if (inputDeviceMaps == null)
                return false;


            if (inputDeviceMaps.InputName != request.InputName)
            {
                inputDeviceMaps.InputName = request.InputName;
            }

            var deviceDataUserMap = await _context.DeviceDataUserMaps
                .Where(x => x.DeviceDataUserMapId == request.DeviceUserMapId &&
                    x.DeviceDataMapId == request.InputId && !x.IsDelete).FirstOrDefaultAsync(cancellationToken);

            if (deviceDataUserMap == null)
            {
                deviceDataUserMap = new DeviceDataUserMap
                {
                    DeviceDataMapId = (int)request.InputId,
                    Contact = request.Contact,
                    ContactHourFrom = request.ContactHourFrom,
                    ContactHourTo = request.ContactHourTo,
                    TimeDelay = request.TimeDelay,
                    Remainder = request.Reminder,
                    Message = request.Message,
                    IsNotification = 1,
                    IsDelete = false,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _currentUserService.AccountId,
                };

                await _context.DeviceDataUserMaps.AddAsync(deviceDataUserMap, cancellationToken);
            }
            else
            {
                deviceDataUserMap.DeviceDataMapId = (int)request.InputId;
                deviceDataUserMap.Contact = request.Contact;
                deviceDataUserMap.ContactHourFrom = request.ContactHourFrom;
                deviceDataUserMap.ContactHourTo = request.ContactHourTo;
                deviceDataUserMap.TimeDelay = request.TimeDelay;
                deviceDataUserMap.Remainder = request.Reminder;
                deviceDataUserMap.Message = request.Message;
                deviceDataUserMap.LastModifiedAt = DateTime.UtcNow;
                deviceDataUserMap.LastModifiedBy = _currentUserService.AccountId;

                _context.DeviceDataUserMaps.Update(deviceDataUserMap);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
