using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartAttend.Application.Common.Constant;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Machine.DTOs;
using SmartAttend.Domain.Entities;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace SmartAttend.Application.Machine.Commands
{
    public class AddMachineCommand : IRequest<PageResponse>
    {
        public CreateMachineRequest createMachineRequest { get; set; }
    }
    public class AddMachineCommandHandler : IRequestHandler<AddMachineCommand, PageResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly MachineConfiguration _machineConfiguration;

        public AddMachineCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IOptions<MachineConfiguration> machineConfig)
        {
            _context = context;
            _currentUserService = currentUserService;
            _machineConfiguration = machineConfig.Value;
        }

        public async Task<PageResponse> Handle(AddMachineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return new PageResponse
                    {
                        IsSuccess = false,
                        Message = "Request is invalid"
                    };
                }
                var machineRequest = request.createMachineRequest;

                Device device = new Device()
                {
                    CustomerId = _currentUserService.CustomerId ?? 0,
                    DeviceId = machineRequest.DeviceId,
                    DeviceName = machineRequest.DeviceName,
                    Size = machineRequest.Size,
                    PartNumber = machineRequest.PartNumber,
                    PressRate = machineRequest.PressRate,
                    MachineID = machineRequest.MachineId,
                    Image = string.Empty,
                    Input7Active = true,
                    MachineTime = 0,
                    Running = true,
                    Alarm = true,
                    IsCommunicating = true,
                    IsPlanned = 0,
                    IsActive = true,
                    IsEmailNotification = true,
                    OffsetDifference = 0,
                    TimeZone = string.Empty,
                    CalculatedCycleTime = string.Empty,
                    ETA = string.Empty,
                    RunningDuration = string.Empty,
                    Description = string.Empty,
                    ChangeOverClr = string.Empty,
                    DowntimeDuration = string.Empty,
                    LastCounterCycleTime = string.Empty,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _currentUserService.CustomerId ?? 0,
                    LastModifiedAt = DateTime.UtcNow,
                    LastModifiedBy = null
                };
                await  _context.Devices.AddAsync(device, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var newInsertedDeviceId = device.DeviceId;

                var deviceConfig = await _context.DeviceConfigs
                    .FirstOrDefaultAsync(d => d.DeviceId == newInsertedDeviceId, cancellationToken);

                if (deviceConfig == null && newInsertedDeviceId > 0)
                {
                    var devConfig = new DeviceConfig
                    {
                        DeviceId = device.Id,
                        ServerIPFirst = _machineConfiguration.ServerIPFirst,
                        ServerIPSecond = _machineConfiguration.ServerIPSecond,
                        PortFirst = _machineConfiguration.PortFirst,
                        PortSecond = _machineConfiguration.PortSecond,
                        ConfigPortOne = _machineConfiguration.ConfigPortOne,
                        ConfigPortTwo = _machineConfiguration.ConfigPortTwo,
                        ConfigIp1Address = _machineConfiguration.ConfigIp1Address,
                        ConfigIp2Address = _machineConfiguration.ConfigIp2Address,
                        MachineId = null,
                        Firm_Update_Required = false,
                        WLAN_SSID = string.Empty,
                        WLAN_Password = string.Empty,
                        Pulse_Values = string.Empty,
                        FTP_UserName = string.Empty,
                        FTP_Password = string.Empty,
                        HostName = string.Empty,
                        FtpFolder = string.Empty,
                        ErrorLog = string.Empty,
                        FirmwareUpdateNo = string.Empty,                   
                        Pulse_Freq = null,
                        IsUpdated = 0,                 
                        IsDelete = false,             
                        ClientIPAddress = string.Empty,
                        ModifiedDate = null,
                        DeviceUpdatedDate = null,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = _currentUserService.CustomerId ?? 0,
                        LastModifiedAt = DateTime.UtcNow,
                        LastModifiedBy = null
                    };

                    await _context.DeviceConfigs.AddAsync(devConfig, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);

                    long newlyInserteddeviceConfigId = devConfig.DeviceConfigId;

                    var configDetailsList = new List<DeviceConfigDetails>();

                    for (int i = 1; i <= 8; i++)
                    {
                        var configDet = new DeviceConfigDetails
                        {
                            DeviceConfigId = newlyInserteddeviceConfigId,
                            Input_No = i == 8 ? "Input8" : $"Input{i}",
                            Delay = i <= 3 ? "5" : "0",
                            OFFDelay = "150",
                            HexColor = string.Empty,
                            Priority = string.Empty,
                            Color = string.Empty,
                            Flash_Speed = string.Empty,
                            Sound = string.Empty,
                        };

                        switch (i)
                        {
                            case 1:
                                configDet.Priority = "1";
                                configDet.Color = "3";
                                configDet.Flash_Speed = "1";
                                configDet.Sound = "1";
                                break;

                            case 2:
                                configDet.Priority = "2";
                                configDet.Color = "6";
                                configDet.Flash_Speed = "1";
                                configDet.Sound = "2";
                                break;

                            case 3:
                                configDet.Priority = "3";
                                configDet.Color = "5";
                                configDet.Flash_Speed = "1";
                                configDet.Sound = "4";
                                break;

                            case 4:
                                configDet.Priority = "4";
                                configDet.Color = "0";
                                configDet.Flash_Speed = "11";
                                configDet.Sound = "4";
                                break;

                            case 5:
                                configDet.Priority = "5";
                                configDet.Color = "0";
                                configDet.Flash_Speed = "11";
                                configDet.Sound = "2";
                                break;

                            case 6:
                                configDet.Priority = "6";
                                configDet.Color = "0";
                                configDet.Flash_Speed = "11";
                                configDet.Sound = "5";
                                break;

                            case 7:
                                configDet.Priority = "7";
                                configDet.Color = "2";
                                configDet.Flash_Speed = "11";
                                configDet.Sound = "0";
                                break;

                            case 8:
                                configDet.Priority = "9";
                                configDet.Color = "3";
                                configDet.Flash_Speed = "11";
                                configDet.Sound = "0";
                                break;
                            }

                        configDetailsList.Add(configDet);
                    }

                    await _context.DeviceConfigDetails.AddRangeAsync(configDetailsList, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }
        

                return new PageResponse
                {
                    IsSuccess = true,
                    Message = "Machine created successfully"
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
