using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Devices.Queries.SaveDeviceConfiguration;

namespace SmartAttend.Application.Devices.Commands.SaveDeviceConfiguration
{
    public class SaveDeviceConfigurationCommandHandler
     : IRequestHandler<SaveDeviceConfigurationCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public SaveDeviceConfigurationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            SaveDeviceConfigurationCommand command,
            CancellationToken cancellationToken)
        {
            var device = await _context.Devices
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (device == null)
                return false;
            device.DeviceId = command.DeviceId;
            device.DeviceName = command.DeviceName;
            device.MachineID = command.MachineTypeId;
            device.PressRate = command.PressRate;
            device.Size = command.Size;

            if (command.Image != null)
            {
                var extension = Path.GetExtension(command.Image.FileName);

                var originalFileName = Path.GetFileName(command.Image.FileName);
                var fileName = $"{device.Id}_{originalFileName}";

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var filePath = Path.Combine(folderPath, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);

                await command.Image.CopyToAsync(stream, cancellationToken);

                device.Image = originalFileName;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}