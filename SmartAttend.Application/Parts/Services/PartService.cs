using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Parts.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Infrastructure.Services
{
    public class PartService : IPartService
    {
        private readonly IApplicationDbContext _dbContext;

        private readonly ICurrentUserService _currentUserService;
        public PartService(IApplicationDbContext dbContext) { _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); }
        public async Task<PartResponseModel> GetPartListAsync()
        {
            var response = new PartResponseModel();
            response.lstPart = new List<Part>();

            try
            {
                var parts = await _dbContext.Parts
                    .OrderByDescending(p => p.CreatedAt)   // Assuming CreatedAt exists in Part
                    .ToListAsync();

                if (parts.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Parts list retrieved successfully";
                    response.lstPart = parts;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "No parts found";
                }
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

        public async Task<PartResponseModel> UpdatePartAsync(UpdatePartDtos dto)
        {
            var response = new PartResponseModel();

            try
            {
                var existingPart = await _dbContext.Parts
                    .FirstOrDefaultAsync(x => x.PartId == dto.PartId);

                if (existingPart == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found.";
                    response.PartId = dto.PartId;
                    return response;
                }

                // Update fields
                existingPart.PartNumber = dto.PartNumber ?? existingPart.PartNumber;
                existingPart.GroupID = dto.GroupID ?? existingPart.GroupID;
                existingPart.Cavity = dto.Cavity ?? existingPart.Cavity;
                existingPart.CycleTime = dto.CycleTime ?? existingPart.CycleTime;
                existingPart.Description = dto.Description ?? existingPart.Description;
                existingPart.PartPrice = dto.PartPrice ?? existingPart.PartPrice;
                existingPart.ScrapPrice = dto.ScrapPrice ?? existingPart.ScrapPrice;
                existingPart.LastModifiedBy = _currentUserService?.AccountId ?? 0;
                existingPart.LastModifiedAt = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Part updated successfully";
                response.PartId = existingPart.PartId;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error updating part: {ex.Message}";
                response.PartId = dto.PartId;
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
                    DowntimeDurationId = assignedParts.DowntimeDurationId,
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
                    DownTimeDurationId = assignedParts.DowntimeDurationId,
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
                assignedParts.DowntimeDurationId = 1;
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
        public async Task<PartResponseModel> AddPartAsync(PartDtos dto)
        {
            var response = new PartResponseModel();

            try
            {
                // Map DTO to Entity
                var newPart = new Part
                {
                    PartNumber = dto.PartNumber,
                    GroupID = dto.GroupID,
                    Cavity = dto.Cavity ?? 0,
                    CycleTime = dto.CycleTime ?? 0,
                    Description = dto.Description,
                    PartPrice = dto.PartPrice ?? 0,
                    ScrapPrice = dto.ScrapPrice ?? 0,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _currentUserService?.AccountId ?? 0,
                    LastModifiedBy = _currentUserService?.AccountId ?? 0,
                    LastModifiedAt = DateTime.UtcNow,
                    
                };

                await _dbContext.Parts.AddAsync(newPart);
                await _dbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Part added successfully";
                response.PartId = newPart.PartId;
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
                var part = await _dbContext.Parts.FindAsync(id);

                if (part == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found";
                    return response;
                }

                _dbContext.Parts.Remove(part);
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
            response.lstPart = new List<Part>();
            try
            {
                var part = await _dbContext.Parts
                    .FirstOrDefaultAsync(x => x.PartId == id);

                if (part != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Part retrieved successfully";
                    response.lstPart.Add(part);

                    
                    response.PartId = part.PartId;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found";
                    response.PartId = id;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error retrieving part: {ex.Message}";
                response.PartId = id;
            }

            return response;
        }

    }
}