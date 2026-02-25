using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Interfaces;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Infrastructure.Services
{
    public class PartService : IPartService
    {
        private readonly IApplicationDbContext _dbContext;

        public PartService(IApplicationDbContext dbContext) { _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); }
        public async Task<PartResponseModel> GetPartListAsync(int customerId)
        {
            var response = new PartResponseModel();

            try
            {
                var partModel = await (
                    from asspart in _dbContext.AssignedParts
                    join device in _dbContext.Devices on asspart.DeviceId equals device.DeviceId
                    join part in _dbContext.Parts on asspart.PartId equals part.PartId
                    where device.CustomerId == customerId
                          && asspart.Status == true
                          && device.IsActive == true
                    orderby device.DeviceName
                    select new AssignedPartsModel
                    {
                        Id = asspart.Id,
                        PartId = asspart.PartId ?? 0,
                        PartNumber = part.PartNumber ?? string.Empty,
                        DeviceName = device.DeviceName ?? asspart.DeviceId.ToString(),
                        GroupID = part.GroupID ?? string.Empty,
                        Cavity = asspart.Cavity ?? 0,
                        CycleTime = asspart.CycleTime.ToString() ?? string.Empty,
                        Scrap = asspart.Scrap ?? 0,
                        GrossQty = asspart.GrossQty,
                        StartDateTime = asspart.StartDateTime.HasValue
                                        ? asspart.StartDateTime.Value.ToString("MM-dd-yyyy HH:mm:ss")
                                        : null,
                        RequiredQuantity = asspart.RequiredQuantity ?? 0
                    }
                ).ToListAsync();

                response.IsSuccess = true;
                response.Message = "Parts Assigned List";
                response.LstAssignedPartModel = partModel;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error fetching parts: {ex.Message}";
            }

            return response;
        }


        public async Task<PartResponseModel> GetUpdatePartbyIdAsync(int id)
        {
            var response = new PartResponseModel();

            try
            {
                var assignedPart = await _dbContext.AssignedParts
                    .Include(x => x.Part)
                    .Include(x => x.Device)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (assignedPart != null)
                {
                    var model = new AssignedPart
                    {
                        Id = assignedPart.Id,
                        PartId = assignedPart.PartId,
                        DeviceId = assignedPart.DeviceId,
                        CycleTime = assignedPart.CycleTime,
                        RequiredQuantity = assignedPart.RequiredQuantity,
                        Cavity = assignedPart.Cavity,
                        Scrap = assignedPart.Scrap,
                        CurrentScrap = assignedPart.CurrentScrap ?? 0,
                        GrossQty = assignedPart.GrossQty,
                        Part = assignedPart.Part,
                        Device = assignedPart.Device
                    };

                    response.IsSuccess = true;
                    response.Message = "Get AssignedPart by ID";
                    response.assignedPart = model;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found";
                    response.assignedPart = null;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Error retrieving AssignedPart";
                response.assignedPart = null;
            }

            return response;
        }


        public async Task<PartResponseModel> UpdatePartAsync(AssignedPart model)
        {
            var response = new PartResponseModel();

            try
            {
                DateTime currentDate = DateTime.Now;

                var assignedParts = await _dbContext.AssignedParts.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (assignedParts == null)
                {
                    response.IsSuccess = false;
                    response.Message = "AssignedPart not found.";
                    return response;
                }

                // Update fields safely
                assignedParts.PartId = model.PartId;
                assignedParts.DeviceId = model.DeviceId;
                assignedParts.Cavity = model.Cavity;
                assignedParts.CycleTime = model.CycleTime;
                assignedParts.RequiredQuantity = model.RequiredQuantity;

                // Scrap and CurrentScrap are nullable → safe with ??
                assignedParts.CurrentScrap = (assignedParts.CurrentScrap ?? 0) + (model.CurrentScrap ?? 0);
                assignedParts.Scrap = (assignedParts.Scrap ?? 0) + (model.Scrap ?? 0);

                assignedParts.AssignedPartDate ??= currentDate;
                assignedParts.StartDateTime ??= currentDate;

                // GrossQty is non-nullable int → just add directly
                assignedParts.GrossQty += model.GrossQty;

                await _dbContext.SaveChangesAsync();

                // Update related DeviceData
                var deviceData = await _dbContext.DeviceDatas
                    .Where(x => x.DeviceId == assignedParts.DeviceId && x.DateTime < currentDate)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();

                if (deviceData != null)
                {
                    // Scrap is int? in DeviceData → safe with ??
                    deviceData.Scrap += (model.CurrentScrap ?? 0);

                    // GrossQty is int → just add directly
                    deviceData.GrossQty += model.GrossQty;

                    await _dbContext.SaveChangesAsync();
                }

                // Update DeviceUserReportMap
                if (model.DeviceId > 0)
                {
                    var userReportMaps = await _dbContext.DeviceUserReportMaps
                        .Where(c => c.DeviceId == model.DeviceId)
                        .ToListAsync();

                    if (userReportMaps.Any())
                    {
                        foreach (var item in userReportMaps)
                        {
                            item.IsActive = true;
                        }
                        await _dbContext.SaveChangesAsync();
                    }
                }

                response.IsSuccess = true;
                response.Message = "Updated Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error updating part: {ex.Message}";
            }

            return response;
        }

        public async Task<PartResponseModel> GetRemovePartAsync(int id)

        {
            var response = new PartResponseModel();

            try
            {
                var assignedParts = await _dbContext.AssignedParts
                    .FirstOrDefaultAsync(x => x.Id == id && x.Status == true);

                if (assignedParts == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Part not Removed";
                    return response;
                }

                // Save AssignedPart to history
                var assignPartHistory = new AssignedPartsHistory
                {
                    PartId = assignedParts.PartId,
                    DeviceId = assignedParts.DeviceId,
                    Cavity = assignedParts.Cavity,
                    CycleTime = assignedParts.CycleTime,
                    RequiredQuantity = assignedParts.RequiredQuantity,
                    CompletedQuantity = assignedParts.CompletedQuantity,
                    StartDateTime = assignedParts.StartDateTime,
                    EndDateTime = DateTime.Now,
                    RunningDuration = assignedParts.RunningDuration,
                    ETA = assignedParts.ETA,
                    Scrap = assignedParts.Scrap,
                    CurrentScrap = assignedParts.CurrentScrap,
                    CalculatedCycleTime = assignedParts.CalculatedCycleTime,
                    Status = false,
                    AssignedPartDate = assignedParts.AssignedPartDate,
                    Efficiency = assignedParts.Efficiency,
                    QtyPercentage = assignedParts.QtyPercentage,
                    DowntimeDurationID = assignedParts.DowntimeDurationID,
                    DowntimeDuration = assignedParts.DowntimeDuration,
                    DowntimePercentage = assignedParts.DowntimePercentage,
                    CreatedAt = DateTime.Now,
                    GrossQty = assignedParts.GrossQty,
                    BackupData = 1
                };
                await _dbContext.AssignedPartsHistories.AddAsync(assignPartHistory);
                await _dbContext.SaveChangesAsync();

                // Save to RemovedAssignedPart
                var removedAssignedPart = new RemovedAssignedPart
                {
                    PartId = assignedParts.PartId,
                    DeviceId = assignedParts.DeviceId,
                    Cavity = assignedParts.Cavity,
                    CycleTime = assignedParts.CycleTime,
                    RequiredQuantity = assignedParts.RequiredQuantity,
                    CompletedQuantity = assignedParts.CompletedQuantity,
                    StartDateTime = assignedParts.StartDateTime,
                    EndDateTime = DateTime.Now,
                    RunningDuration = assignedParts.RunningDuration,
                    ETA = assignedParts.ETA,
                    Scrap = assignedParts.Scrap,
                    CurrentScrap = assignedParts.CurrentScrap,
                    CalculatedCycleTime = assignedParts.CalculatedCycleTime,
                    Status = false,
                    AssignedPartDate = assignedParts.AssignedPartDate,
                    Efficiency = assignedParts.Efficiency,
                    QtyPercentage = assignedParts.QtyPercentage,
                    DownTimeDurationId = assignedParts.DowntimeDurationID,
                    DowntimeDuration = assignedParts.DowntimeDuration,
                    DownTimePercentage = assignedParts.DowntimePercentage,
                    GrossQty = assignedParts.GrossQty,
                    BackupData = 0,
                    CreatedAt = DateTime.Now
                };
                await _dbContext.RemovedAssignedParts.AddAsync(removedAssignedPart);
                await _dbContext.SaveChangesAsync();

                // Scrap history cleanup
                var part = await _dbContext.Parts.FirstOrDefaultAsync(x => x.PartId == assignedParts.PartId);
                if (part != null && !string.IsNullOrEmpty(part.GroupID))
                {
                    var Parts = await _dbContext.Parts
                        .Where(x => x.GroupID == part.GroupID && x.Customer == part.Customer)
                        .ToListAsync();

                    foreach (var item in Parts.Where(p => p.PartId != assignedParts.PartId))
                    {
                        var Scrap = await _dbContext.Scraps.Where(x => x.PartId == item.PartId).ToListAsync();
                        if (Scrap.Any())
                        {
                            foreach (var scrp in Scrap)
                            {
                                var scrapHistory = new ScrapHistory
                                {
                                    PartId = item.PartId,
                                    DeviceId = scrp.DeviceId,
                                    ScrapCount = scrp.ScrapCount,
                                    StartDateTime = scrp.StartDateTime,
                                    EndDateTime = DateTime.Now,
                                    CreatedAt = scrp.CreatedAt
                                };
                                await _dbContext.ScrapHistories.AddAsync(scrapHistory);
                            }
                            await _dbContext.SaveChangesAsync();

                            _dbContext.Scraps.RemoveRange(Scrap);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }

                // Reset AssignedPart
                assignedParts.PartId = 0;
                assignedParts.Cavity = 0;
                assignedParts.CycleTime = 0;
                assignedParts.RequiredQuantity = 0;
                assignedParts.CompletedQuantity = 0;
                assignedParts.StartDateTime = null;
                assignedParts.EndDateTime = null;
                assignedParts.RunningDuration = "00:00:00";
                assignedParts.ETA = "00:00hrs";
                assignedParts.Scrap = 0;
                assignedParts.CurrentScrap = 0;
                assignedParts.CalculatedCycleTime = "00:00:00";
                assignedParts.Status = true;
                assignedParts.Efficiency = 0;
                assignedParts.QtyPercentage = 0;
                assignedParts.DowntimeDurationID = 1;
                assignedParts.DowntimeDuration = "00:00";
                assignedParts.GrossQty = 0;
                assignedParts.AssignedPartDate = null;

                await _dbContext.SaveChangesAsync();

                // Reset Device
                var device = await _dbContext.Devices.FirstOrDefaultAsync(x => x.DeviceId == assignedParts.DeviceId && x.IsActive);
                if (device != null)
                {
                    device.PartNumber = "";
                    device.CalculatedCycleTime = "00:00:00";
                    device.CompletedQuantity = 0;
                    device.ETA = "00:00hrs";
                    device.Efficiency = 0;
                    device.RunningDuration = "00:00:00";
                    device.QtyPercentage = 0;
                    device.StartDateTime = null;
                    device.DowntimeDurationID = 1;
                    device.DowntimeDuration = "00:00";
                    device.DowntimePercentage = 0;
                    await _dbContext.SaveChangesAsync();
                }

                response.IsSuccess = true;
                response.Message = "Part Removed Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error removing part: {ex.Message}";
            }

            return response;
        }
        public async Task<PartResponseModel> AddPartAsync(AssignedPart model)
        {
            var response = new PartResponseModel();

            try
            {
                DateTime currentDate = DateTime.Now;

                // Initialize new AssignedPart
                var newPart = new AssignedPart
                {
                    PartId = model.PartId,
                    DeviceId = model.DeviceId,
                    Cavity = model.Cavity,
                    CycleTime = model.CycleTime,
                    RequiredQuantity = model.RequiredQuantity,
                    CurrentScrap = model.CurrentScrap ?? 0,
                    Scrap = model.Scrap ?? 0,
                    AssignedPartDate = currentDate,
                    StartDateTime = currentDate,
                    GrossQty = model.GrossQty
                };

                await _dbContext.AssignedParts.AddAsync(newPart);
                await _dbContext.SaveChangesAsync();

                // Update related DeviceData
                var deviceData = await _dbContext.DeviceDatas
                    .Where(x => x.DeviceId == newPart.DeviceId && x.DateTime < currentDate)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();

                if (deviceData != null)
                {
                    deviceData.Scrap += (model.CurrentScrap ?? 0);
                    deviceData.GrossQty += model.GrossQty;
                    await _dbContext.SaveChangesAsync();
                }

                // Update DeviceUserReportMap
                if (model.DeviceId > 0)
                {
                    var userReportMaps = await _dbContext.DeviceUserReportMaps
                        .Where(c => c.DeviceId == model.DeviceId)
                        .ToListAsync();

                    if (userReportMaps.Any())
                    {
                        foreach (var item in userReportMaps)
                        {
                            item.IsActive = true;
                        }
                        await _dbContext.SaveChangesAsync();
                    }
                }

                response.IsSuccess = true;
                response.Message = "Part added successfully";
                response.PartId = newPart.Id;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error adding part: {ex.Message}";
            }

            return response;
        }
        public async Task<PartResponseModel> RemovePartAsync(int id)
        {
            var response = new PartResponseModel();

            try
            {
                var part = await _dbContext.AssignedParts.FindAsync(id);

                if (part == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found";
                    return response;
                }

                _dbContext.AssignedParts.Remove(part);
                await _dbContext.SaveChangesAsync();
                 
                response.IsSuccess = true;
                response.Message = "Part removed successfully";
                response.PartId = id;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error removing part: {ex.Message}";
            }

            return response;
        }
        public async Task<PartResponseModel> GetPartByIdAsync(int id)
        {
            var response = new PartResponseModel();

            try
            {
                var part = await _dbContext.AssignedParts
                    .Include(x => x.Part)   
                    .Include(x => x.Device) 
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (part != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Part retrieved successfully";

                    response.assignedPart = new AssignedPart
                    {
                        Id = part.Id,
                        PartId = part.PartId,
                        DeviceId = part.DeviceId,
                        CycleTime = part.CycleTime,
                        RequiredQuantity = part.RequiredQuantity,
                        Cavity = part.Cavity,
                        Scrap = part.Scrap,
                        CurrentScrap = part.CurrentScrap,
                        GrossQty = part.GrossQty,
                        Part = part.Part,
                        Device = part.Device
                    };
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found";
                    response.assignedPart = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error retrieving part: {ex.Message}";
                response.assignedPart = null;
            }

            return response;
        }
    }
}