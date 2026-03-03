using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace SmartAttend.Application.Notifications.Commands
{
    public class NotificationOffCommand : IRequest<PageResponse>
    {
        public int InputId { get; set; }
        public int InputNotification { get; set; }
        public int MachineShutdown { get; set; }
        public long DeviceId { get; set; }
        public int AccountId { get; set; }
        public string InputName { get; set; }
        public int Description { get; set; }
        public int MachineDowntime { get; set; }
        public string OtherShutdown { get; set; }
        public string OtherDowntime { get; set; }
    }

    public class NotificationOffHandler : IRequestHandler<NotificationOffCommand, PageResponse>
    {
        private readonly IApplicationDbContext _context;

        public NotificationOffHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PageResponse> Handle(NotificationOffCommand request, CancellationToken cancellationToken)
        {
            string partNumber = string.Empty;
            PageResponse Response = new PageResponse();
            try
            {
                if (request.InputId == 0)
                {
                    if (request.InputId == 0)
                    {
                        await HandleNoErrorNotificationAsync(request.DeviceId, request.AccountId, request.InputName, request.InputNotification, cancellationToken);
                    }

                }
                else
                {
                    var result = await _context.DeviceDataUserMaps.Where(x => x.DeviceDataUserMapId == request.InputId).FirstOrDefaultAsync();
                    var device = await _context.Devices.Where(x => x.DeviceId == request.DeviceId).FirstOrDefaultAsync();
                    var devicedata = await _context.DeviceDatas.Where(x => x.DeviceId == request.DeviceId).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                    var description = await _context.PlannedShutdownDescriptions.Where(x => x.Id == request.Description && x.DeviceId == request.DeviceId && !x.IsDelete).FirstOrDefaultAsync();

                    if (devicedata == null)
                    {
                        return new PageResponse() { IsSuccess = false, Message = "Devicedata is Not Found" };
                    }

                    if ((devicedata.Input7 == 1 && request.MachineShutdown == 2) || (devicedata.Input7 == 1 && request.MachineDowntime == 3))
                    {
                        Response.IsSuccess = true;
                        Response.Message = "This device couldn't shutdown due to running status.";
                        //Library.WriteErrorLog(" Trace3 Model : " + request.DeviceID + "  InputName : " + request.InputName);
                    }
                    else
                    {
                        if (result == null)
                        {
                            return new PageResponse() { IsSuccess = false, Message = "DeviceDataUserMaps is Not Found" };
                        }
                        if (request.MachineShutdown == 2)
                        {
                            if (request.OtherShutdown != "")
                            {
                                description.Description = request.OtherShutdown;
                                await _context.SaveChangesAsync(cancellationToken);
                            }

                            var devicedatauserDetails = await _context.DeviceDataUserMaps
                                .Include(x => x.DeviceDataMap)
                                .ThenInclude(x => x.Device)
                                .Where(x => x.DeviceDataMapId == result.DeviceDataMapId).ToListAsync(cancellationToken);

                            await AddNotificationHistoryAsync(device.DeviceId, request, cancellationToken);

                            AssignedPart assignPart = await _context.AssignedParts
                                                        .Include(x => x.Part)
                                                        .Where(x => x.DeviceId == request.DeviceId && x.Status == true).FirstOrDefaultAsync(cancellationToken);
                            if (assignPart is null)
                            {
                                return new PageResponse() { IsSuccess = false, Message = "assignPart is not found" };
                            }

                            await HandlePlannedShutdownAsync(description.PlannedShutdownDescriptionMaster.Id, assignPart, cancellationToken);


                            var deviceDataUserMapIds = devicedatauserDetails.Select(x => x.DeviceDataUserMapId).ToList();
                            _ = await _context.Notifications
                                    .Where(x => deviceDataUserMapIds.Contains((int)x.DeviceDataUserMapId) &&
                                                !x.IsDelete)
                                    .ExecuteUpdateAsync(
                                        update => update
                                            .SetProperty(x => x.IsDelete, true)
                                            .SetProperty(x => x.UpdatedDate, DateTime.Now),
                                        cancellationToken
                                    );

                            foreach (var item in devicedatauserDetails)
                            {
                                item.IsNotification = request.MachineShutdown;
                                item.UpdatedDate = DateTime.Now;
                                item.DeviceDataMap.Device.DescriptionId = description.PlannedShutdownDescriptionMaster.Id;
                                item.DeviceDataMap.Device.Description = description.Description;
                                item.DeviceDataMap.Device.IsPlanned = request.MachineShutdown;
                                item.DeviceDataMap.Device.SinglePlannedDate = DateTime.Now;
                                item.DeviceDataMap.Device.LastModifiedAt = DateTime.Now;
                                await _context.SaveChangesAsync(cancellationToken);
                                // Library.WriteErrorLog(" Trace4 Changes done in DevicedataUserMap ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown);
                            }

                            await HandlePlannedShutdownTrackingAsync(description, devicedata, device);
                            await _context.SaveChangesAsync(cancellationToken);

                            //Start                        
                            DateTime tmzDate = DateTime.Now;
                            DateTime startDate = devicedata.DateTime.HasValue ? devicedata.DateTime.Value : DateTime.Now;
                            DateTime endDate = tmzDate;
                            DateTime roundDate = RoundUp(startDate.AddMilliseconds(1), TimeSpan.FromHours(1));
                            TimeSpan timeDiff1 = roundDate.Subtract(startDate);
                            TimeSpan timeDiff2 = endDate.Subtract(startDate);

                            if (devicedata != null)
                            {
                                if (timeDiff1.TotalMinutes < timeDiff2.TotalMinutes)
                                {
                                    await DeviceDataTracking(request, startDate, description, roundDate);
                                    // Library.WriteErrorLog(" Trace8 Changes done in new DeviceDataTracking ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);

                                    double totHours = Math.Round(timeDiff2.TotalHours);
                                    if (totHours > 1)
                                    {
                                        for (int i = 1; i <= totHours; i++)
                                        {
                                            startDate = roundDate;
                                            roundDate = RoundUp(roundDate.AddMilliseconds(1), TimeSpan.FromHours(1));
                                            if (startDate < DateTime.Now && roundDate < DateTime.Now)
                                            {
                                                await DeviceDataTracking(request, startDate, description, roundDate);
                                                //Library.WriteErrorLog(" Trace9 Changes done in new DeviceDataTracking ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);

                                            }
                                        }
                                    }
                                    DeviceDataTracking lastItem = await _context.DeviceDataTrackings.Where(x => x.DeviceId == device.DeviceId
                                                                && x.InputName == "Input7").OrderByDescending(x => x.CreatedDateTime)
                                                                .FirstOrDefaultAsync(cancellationToken);

                                    await DeviceDataTracking(request, lastItem.EndDateTime.Value, description, roundDate, endDate);
                                    //Library.WriteErrorLog(" Trace10 Changes done in new DeviceDataTracking ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                }
                                else
                                {
                                    await DeviceDataTracking(request, startDate, description, roundDate, endDate);
                                    //Library.WriteErrorLog(" Trace11 Changes done in new DeviceDataTracking ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                }
                                //Start
                                if (timeDiff1.TotalMinutes < timeDiff2.TotalMinutes)
                                {
                                    await DeviceDataTracking(request, startDate, description, roundDate);
                                    // Library.WriteErrorLog(" Trace11 Changes done in new DeviceDataTracking ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                    double totHours = Math.Round(timeDiff2.TotalHours);
                                    if (totHours > 1)
                                    {
                                        startDate = roundDate;
                                        roundDate = RoundUp(roundDate.AddMilliseconds(1), TimeSpan.FromHours(1));
                                        if (startDate < DateTime.Now && roundDate < DateTime.Now)
                                        {
                                            await DeviceDataTracking(request, startDate, description, roundDate);
                                            //Library.WriteErrorLog(" Trace13 Changes done in new DeviceTrackingDay ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);

                                        }
                                    }
                                    DeviceTrackingDays lastItem = _context.DeviceTrackingDays.Where(x => x.DeviceId == device.DeviceId && x.InputName == "Input7").OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();
                                    await DeviceDataTracking(request, lastItem.EndDateTime.Value, description, roundDate);
                                    // Library.WriteErrorLog(" Trace14 Changes done in new DeviceTrackingDay ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                }
                                else
                                {
                                    await DeviceDataTracking(request, startDate, description, roundDate);
                                    //Library.WriteErrorLog(" Trace15 Changes done in new DeviceTrackingDay ----> : " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                }
                            }
                        }
                        else if (request.InputNotification == 1)
                        {
                            NotificationHistory notification = new NotificationHistory();
                            notification.DeviceId = device.DeviceId;
                            notification.ContactId = request.AccountId;
                            notification.InputName = request.InputName;
                            notification.ReasonId = request.InputNotification;
                            notification.Reason = "No error notification for this event";
                            notification.CreatedAt = DateTime.Now;
                            await _context.NotificationHistories.AddAsync(notification);
                            await _context.SaveChangesAsync();

                            result.IsNotification = request.InputNotification;
                            result.UpdatedDate = DateTime.Now;
                            await _context.SaveChangesAsync();

                            await _context.Notifications
                                       .Where(x => x.DeviceDataUserMapId == request.InputId &&
                                                   x.AccountId == request.AccountId &&                                                 
                                                  !x.IsDelete)
                                       .ExecuteUpdateAsync(update => update
                                           .SetProperty(x => x.IsDelete, true)
                                           .SetProperty(x => x.UpdatedDate, DateTime.UtcNow),
                                           cancellationToken);
                        
                        }
                        else if (request.MachineDowntime == 3)
                        {
                            if (request.OtherDowntime != "")
                            {
                                description.Description = request.OtherDowntime;
                                await _context.SaveChangesAsync();
                            }

                            var lstDevicedatauser = await _context.DeviceDataUserMaps.Where(x => x.DeviceDataMapId == result.DeviceDataMapId).ToListAsync();
                            foreach (var item in lstDevicedatauser)
                            {
                                NotificationHistory notification = new NotificationHistory();
                                notification.DeviceId = device.DeviceId;
                                notification.ContactId = request.AccountId;
                                notification.InputName = request.InputName;
                                notification.ReasonId = request.MachineShutdown;
                                notification.Reason = "Machine Stopped";
                                notification.CreatedAt = DateTime.Now;
                                await _context.NotificationHistories.AddAsync(notification);
                                await _context.SaveChangesAsync();

                                item.IsNotification = request.MachineShutdown;
                                item.UpdatedDate = DateTime.Now;
                                await _context.SaveChangesAsync();

                                device.DescriptionId = description.PlannedShutdownDescriptionMaster.Id;
                                device.Description = description.Description;
                                device.DownTimeDate = DateTime.Now;
                                device.LastModifiedAt = DateTime.Now;
                                await _context.SaveChangesAsync();

                                var lstNotification = await _context.Notifications.Where(x => x.DeviceDataUserMapId == item.DeviceDataUserMapId && !x.IsDelete).ToListAsync();
                                foreach (var item_ in lstNotification)
                                {
                                    item_.IsDelete = true;
                                    await _context.SaveChangesAsync();
                                }
                            }

                            //Added for Plannedshutdown Description ID
                            DateTime tmz_Date = DateTime.Now;
                            var device_data = _context.DeviceDatas.Where(x => x.DeviceId == device.DeviceId && x.Input7 == 1).OrderByDescending(x => x.Id).FirstOrDefault();
                            if (device_data != null)
                            {
                                var lstDeviceTraking =  await _context.DeviceDataTrackings.Where(x => x.DeviceId == device.DeviceId && x.InputName == "Input7" 
                                            && x.StartDateTime >= device_data.DateTime && x.EndDateTime <= tmz_Date).ToListAsync();
                                int count = 0;
                                foreach (var deviceTrk in lstDeviceTraking)
                                {
                                    deviceTrk.Reasonprevious = "7";
                                    if (count == 0)
                                        deviceTrk.CurrentShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;//Added for Plannedshutdown Description ID
                                    else
                                    {
                                        deviceTrk.CurrentShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;
                                        deviceTrk.PlannedShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;
                                    }
                                    await _context.SaveChangesAsync();
                                    count++;
                              //      Library.WriteErrorLog(" Trace16 Changes done in DeviceDataTracking count----> : " + count + " " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                }

                                var lstDeviceTrakingDay = await _context.DeviceTrackingDays.Where(x => x.DeviceId == device.DeviceId 
                                        && x.InputName == "Input7" && x.StartDateTime >= device_data.DateTime && x.EndDateTime <= tmz_Date).ToListAsync();
                                int countDay = 0;
                                foreach (var deviceTrkDay in lstDeviceTrakingDay)
                                {
                                    deviceTrkDay.Reasonprevious = "7";
                                    if (countDay == 0)
                                        deviceTrkDay.CurrentShutdownMasterID = description.PlannedShutdownDescriptionMaster.Id;//Added for Plannedshutdown Description ID
                                    else
                                    {
                                        deviceTrkDay.CurrentShutdownMasterID = description.PlannedShutdownDescriptionMaster.Id;
                                        deviceTrkDay.PlannedShutdownMasterID = description.PlannedShutdownDescriptionMaster.Id;
                                    }
                                    await _context.SaveChangesAsync();
                                    countDay++;
                                    //Library.WriteErrorLog(" Trace17 Changes done in DeviceTrackingDay count----> : " + countDay + " " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                                }
                            }
                        }
                        Response.IsSuccess = true;
                        Response.Message = "Updated Sccessfully";                    }
                }
                return Response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task DeviceDataTracking(NotificationOffCommand notificationOffCommand, DateTime startDate,
            PlannedShutdownDescription description, DateTime roundDate, DateTime? endDate = null, bool isCreatedDateTime = false)
        {
            try
            {
                DeviceDataTracking newItem1 = new DeviceDataTracking();
                newItem1.DeviceId = notificationOffCommand.DeviceId;
                newItem1.InputName = "Input7";
                newItem1.Value = 0;
                newItem1.CreatedDateTime = startDate;
                newItem1.StartDateTime = startDate;
                newItem1.EndDateTime = endDate ?? roundDate;
                newItem1.Duration = 0;
                newItem1.Reasoncurrent = "8";
                newItem1.Reasonprevious = "8";
                newItem1.CurrentShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;//Added for Plannedshutdown Description ID
                newItem1.PlannedShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;//Added for Plannedshutdown Description ID
                newItem1.Stopduration = GetDateTimeDiffence(startDate, roundDate);
                newItem1.IsManual = true;
                await _context.DeviceDataTrackings.AddAsync(newItem1);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public double GetDateTimeDiffence(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                TimeSpan duration = EndDate.Subtract(StartDate);
                int hours = duration.Days * 24;
                hours += duration.Hours;
                int minutes = duration.Minutes;
                int seconds = duration.Seconds;
                //string HoursToSave = hours.ToString().Length == 1 ? "0" + hours.ToString()+":" : hours.ToString() + ":";
                //HoursToSave += minutes.ToString().Length == 1 ? "0" + minutes.ToString()+":" : minutes.ToString() + ":";
                //HoursToSave += seconds.ToString().Length == 1 ? "0" + seconds.ToString(): seconds.ToString();
                return TimeSpan.FromSeconds(duration.TotalSeconds).TotalSeconds;
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }

        private async Task HandleNoErrorNotificationAsync(
                            long deviceId,
                            int accountId,
                            string inputName,
                            int inputNotification,                          
                            CancellationToken cancellationToken, 
                            bool isNotificationReason = false)
        {
            try
            {
                var notification = new NotificationHistory
                {
                    DeviceId = deviceId,
                    ContactId = accountId,
                    InputName = inputName,
                    ReasonId = inputNotification,
                    Reason = isNotificationReason ? "Machine Stopped" : "No error notification for this event",
                    CreatedAt = DateTime.UtcNow
                };

                await _context.NotificationHistories.AddAsync(notification, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);


                await _context.Notifications
                    .Where(x => x.DeviceId == deviceId &&
                                x.AccountId == accountId &&
                                x.EntityType == 2 &&
                                !x.IsDelete)
                    .ExecuteUpdateAsync(update => update
                        .SetProperty(x => x.IsDelete, true)
                        .SetProperty(x => x.UpdatedDate, DateTime.UtcNow),
                        cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private async Task HandlePlannedShutdownTrackingAsync(PlannedShutdownDescription description, DeviceData devicedata, Device device)
        {
            try
            {
                DateTime tmz_Date = DateTime.Now;
                var deviceData = await _context.DeviceDatas
                                .Where(x => x.DeviceId == device.DeviceId && x.Input7 == 1)
                                .OrderByDescending(x => x.Id)
                                .FirstOrDefaultAsync();

                if (deviceData == null)
                    return;

                var deviceTrakingDetails = await _context.DeviceDataTrackings
                                        .Where(x => x.DeviceId == device.DeviceId && x.InputName == "Input7"
                                        && x.StartDateTime >= devicedata.DateTime && x.EndDateTime <= tmz_Date && x.Reasonprevious != null)
                                        .ToListAsync();

                int count = 0;
                foreach (var deviceTrk in deviceTrakingDetails)
                {
                    deviceTrk.Reasonprevious = "8";
                    deviceTrk.CurrentShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;
                    if (count > 0)
                    {
                        deviceTrk.PlannedShutdownMasterId = description.PlannedShutdownDescriptionMaster.Id;
                    }

                    count++;
                }
                //Library.WriteErrorLog(" Trace7 Changes done in DeviceTrackingDay count----> : " + count1 + " " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);

                var lstDeviceTrkDay = await _context.DeviceTrackingDays.Where(x => x.DeviceId == device.DeviceId && x.InputName == "Input7"
                                        && x.StartDateTime >= devicedata.DateTime && x.EndDateTime <= tmz_Date && x.Reasonprevious != null)
                                        .ToListAsync();
                int count1 = 0;
                foreach (var deviceTrkDay in lstDeviceTrkDay)
                {
                    deviceTrkDay.Reasonprevious = "8";
                    deviceTrkDay.CurrentShutdownMasterID = description.PlannedShutdownDescriptionMaster.Id;

                    if (count1 > 0)
                    {
                        deviceTrkDay.PlannedShutdownMasterID = description.PlannedShutdownDescriptionMaster.Id;
                    }

                    count1++;
                    //Library.WriteErrorLog(" Trace7 Changes done in DeviceTrackingDay count----> : " + count1 + " " + model.DeviceID + "  InputName : " + model.InputName + " DesccriptionId " + description.PlannedShutdownDescriptionMaster.ID + " MachineShutdown " + model.MachineShutdown + " CurrentShutdownMasterID " + description.PlannedShutdownDescriptionMaster.ID);
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private async Task AddNotificationHistoryAsync(
                                long deviceId,
                                NotificationOffCommand notificationOffCommand,
                                CancellationToken cancellationToken)
        {
            try
            {
                var notification = new NotificationHistory
                {
                    DeviceId = deviceId,
                    ContactId = notificationOffCommand.AccountId,
                    InputName = notificationOffCommand.InputName,
                    ReasonId = notificationOffCommand.MachineShutdown,
                    Reason = "Planned machine shutdown",
                    CreatedAt = DateTime.UtcNow
                };

                await _context.NotificationHistories.AddAsync(notification, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private async Task HandlePlannedShutdownAsync(
                            int descriptionId,
                            AssignedPart assignPart,
                            CancellationToken cancellationToken)
        {
            try
            {
                if (descriptionId != 2)
                    return;

                if (assignPart.PartId > 0)
                {
                    var history = new AssignedPartsHistory
                    {
                        PartId = assignPart.PartId,
                        DeviceId = assignPart.DeviceId,
                        Cavity = assignPart.Cavity,
                        CycleTime = assignPart.CycleTime,
                        RequiredQuantity = assignPart.RequiredQuantity,
                        CompletedQuantity = assignPart.CompletedQuantity,
                        StartDateTime = assignPart.StartDateTime,
                        EndDateTime = DateTime.UtcNow,
                        RunningDuration = assignPart.RunningDuration,
                        ETA = assignPart.ETA,
                        Scrap = assignPart.Scrap,
                        CurrentScrap = assignPart.CurrentScrap,
                        CalculatedCycleTime = assignPart.CalculatedCycleTime,
                        Status = false,
                        AssignedPartDate = assignPart.AssignedPartDate,
                        Efficiency = assignPart.Efficiency,
                        QtyPercentage = assignPart.QtyPercentage,
                        DowntimeDurationId = assignPart.DowntimeDurationId,
                        DowntimeDuration = assignPart.DowntimeDuration,
                        DowntimePercentage = assignPart.DowntimePercentage,
                        CreatedAt = DateTime.UtcNow,
                        BackupData = 1
                    };

                    await _context.AssignedPartsHistories.AddAsync(history, cancellationToken);
                }

                assignPart.PartId = 0;
                assignPart.Cavity = 0;
                assignPart.CycleTime = 0;
                assignPart.RequiredQuantity = 0;
                assignPart.CompletedQuantity = 0;
                assignPart.StartDateTime = DateTime.UtcNow;
                assignPart.EndDateTime = null;
                assignPart.RunningDuration = "00:00:00";
                assignPart.ETA = "00:00hrs";
                assignPart.Scrap = 0;
                assignPart.CurrentScrap = 0;
                assignPart.CalculatedCycleTime = "00:00:00";
                assignPart.Status = true;
                assignPart.Efficiency = 0;
                assignPart.QtyPercentage = 0;
                assignPart.AssignedPartDate = DateTime.UtcNow;
                assignPart.DowntimeDurationId = 1;
                assignPart.DowntimeDuration = "00:00";
                assignPart.DowntimePercentage = 0;
                assignPart.LastModifiedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


    }
}
