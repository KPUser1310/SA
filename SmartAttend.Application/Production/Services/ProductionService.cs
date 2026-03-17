using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Interface;
using SmartAttend.Application.Parts.DTOs;
using SmartAttend.Application.Production.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Production.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public ProductionService(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }
        public async Task<AssignedPartsResponseModel> GetAssignedPartsAsync()
        {
            var response = new AssignedPartsResponseModel
            {
                AssignedPartDetails = new List<AssignedPartsDtos>()
            };

            try
            {
                var customerId = _currentUserService.CustomerId;

                if (!customerId.HasValue || customerId.Value == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "CustomerId could not be resolved from user context.";
                    return response;
                }

                var assignedParts = await _dbContext.AssignedParts.AsNoTracking()
                    .Include(a => a.Device)
                    .Include(a => a.Part)
                    .Where(a => a.Device.CustomerId == customerId.Value
                                && a.Status == true
                                && a.Device.IsActive == true)
                    .OrderBy(a => a.Device.DeviceName)
                    .Select(a => new AssignedPartsDtos
                    {
                        Id = a.Id,
                        DeviceId = a.DeviceId,
                        PartId = a.PartId,
                        PartNumber = a.Part.PartNumber,
                        MachineName = string.IsNullOrEmpty(a.Device.DeviceName)
                                        ? a.DeviceId.ToString()
                                        : a.Device.DeviceName,
                        Cavity = a.Cavity ?? 0,
                        CycleTime = a.CycleTime.HasValue
                                        ? Math.Round(a.CycleTime.Value, 2)
                                        : null,
                        Scrap = a.Scrap ?? 0,
                        StartDateTime = a.StartDateTime.HasValue
                                        ? a.StartDateTime.Value.ToString("g")
                                        : null,
                        RequiredQuantity = a.RequiredQuantity ?? 0
                    })
                    .ToListAsync();

                response.IsSuccess = true;
                response.Message = "Assigned parts retrieved successfully";
                response.AssignedPartDetails = assignedParts;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "An error occurred while fetching assigned parts.";
            }
            return response;
        }

        public async Task<AssignedPartsResponseModel> UpdateAssignedPartAsync(UpdateAssignedPartDtos request, CancellationToken cancellationToken)
        {
            var response = new AssignedPartsResponseModel
            {
                UpdateAssignedPartDetails = new List<UpdateAssignedPartDtos>()
            };

            try
            {
                DateTime currentDate = DateTime.Now;

                var result = await _dbContext.AssignedParts
                    .Include(a => a.Device)
                    .Include(a => a.Part)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Part not found";
                    return response;
                }

                // Map fields that exist in AssignedPart
                result.PartId = request.PartId;
                result.DeviceId = request.DeviceId;
                result.Cavity = request.Cavity;
                result.CycleTime = request.CycleTime;
                result.RequiredQuantity = request.RequiredQuantity;

                // Scrap & GrossQty accumulation (entity properties are long)
                if (request.CurrentScrap.HasValue)
                {
                    result.CurrentScrap += request.CurrentScrap.Value;
                    result.Scrap += request.CurrentScrap.Value;
                }

                if (request.GrossQty.HasValue)
                {
                    result.GrossQty += request.GrossQty.Value;
                }

                result.AssignedPartDate ??= currentDate;
                result.StartDateTime ??= currentDate;

                await _dbContext.SaveChangesAsync(cancellationToken);

                // Build response DTO
                response.UpdateAssignedPartDetails.Add(new UpdateAssignedPartDtos
                {
                    Id = result.Id,
                    PartId = result.PartId,
                    PartNumber = result.Part?.PartNumber, // from navigation property
                    MachineName = result.Device?.DeviceName,
                    DeviceId = (int)result.DeviceId,
                    Cavity = result.Cavity,
                    CycleTime = result.CycleTime,
                    RequiredQuantity = result.RequiredQuantity,
                    CurrentScrap = (int)result.CurrentScrap,
                    Scrap = (int)result.Scrap,
                    GrossQty = (int)result.GrossQty
                });

                response.IsSuccess = true;
                response.Message = "Assigned part updated successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error updating part: {ex.InnerException?.Message ?? ex.Message}";
            }

            return response;
        }


        //AddScrap BL
        public async Task<AddScrapResponseDto> AddScrapAsync(AddScrapDto dto)
            {
                var response = new AddScrapResponseDto();
                try
                {
                    var accountId = _currentUserService.AccountId;
                    var userName = $"{_currentUserService.FirstName} {_currentUserService.LastName}".Trim();

                    if (dto.PartID <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Invalid PartID";
                        return response;
                    }

                    int partId = dto.PartID;
                    int scrapCount = dto.ScrapCount;

                    // ✅ Resolve scrap reason from scrapType tbl — ScrapOther handled here using Notes
                    string scrapReason = "";
                    if (dto.ScrapType > 0)
                    {
                        if (dto.ScrapType == 5)
                        {
                            scrapReason = dto.Notes ?? "";
                        }
                        else
                        {
                            scrapReason = await _dbContext.ScrapTypes
                                .Where(x => x.ScrapTypeId == dto.ScrapType && x.IsDelete == false)
                                .Select(x => x.Description)
                                .FirstOrDefaultAsync() ?? "";
                        }
                    }

                    // Updates if record exists AssignedPart/ reads and updates devicedata if assignedpart exists
                    var assignedPart = await _dbContext.AssignedParts
                        .FirstOrDefaultAsync(x => x.PartId == partId
                                               && x.DeviceId == dto.DeviceId
                                               && x.IsDelete == false);
                    if (assignedPart != null)
                    {
                        assignedPart.CurrentScrap = (assignedPart.CurrentScrap ?? 0) + scrapCount;
                        assignedPart.Scrap = (assignedPart.Scrap ?? 0) + scrapCount;
                        assignedPart.LastModifiedAt = DateTime.UtcNow;
                        assignedPart.LastModifiedBy = accountId;
                        await _dbContext.SaveChangesAsync();

                        //as of now we are not updating scrap count in device data as it is not clear, if needed in future we can use this logic 
                        //var deviceData = await _dbContext.DeviceDatas
                        //    .Where(x => x.DeviceId == assignedPart.DeviceId
                        //             && x.DateTime < DateTime.UtcNow
                        //             && x.IsDelete == false)
                        //    .OrderByDescending(x => x.Id)
                        //    .FirstOrDefaultAsync();
                        //if (deviceData != null)
                        //{
                        //    deviceData.Scrap = deviceData.Scrap + scrapCount;
                        //    await _dbContext.SaveChangesAsync();
                        //}
                    }

                    // Insert Scrap record
                    if (scrapCount > 0)
                    {
                        var scrap = new Scrap
                        {
                            PartId = partId,
                            DeviceId = dto.DeviceId,
                            ScrapCount = scrapCount,
                            StartDateTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                            ScrapReason = scrapReason,
                            Notes = dto.Notes,
                            UserName = userName, // ✅ From claims, not from request
                            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                            CreatedBy = accountId
                        };
                        await _dbContext.Scraps.AddAsync(scrap);
                        await _dbContext.SaveChangesAsync();
                    }

                    response.IsSuccess = true;
                    response.Message = "Scrap added successfully";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = $"Error adding scrap: {ex.Message}";
                }
                return response;
            }
        }
    }


















