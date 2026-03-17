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

        public PartService(
            IApplicationDbContext dbContext,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public async Task<PartResponseModel> GetPartListAsync()
        {
            var response = new PartResponseModel();
            response.lstPart = new List<Part>();

            try
            {
                var parts = await _dbContext.Parts
                    .Where(p => p.IsDelete == false)
                    .OrderByDescending(p => p.CreatedAt)
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

        public async Task<PartResponseModel> AddPartAsync(PartDtos dto)
        {
            var response = new PartResponseModel();

            try
            {
                var customerId = _currentUserService.CustomerId;
                var accountId = _currentUserService.AccountId;

                if (!customerId.HasValue || customerId.Value == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "CustomerId could not be resolved from user context.";
                    return response;
                }

                var newPart = new Part
                {
                    PartNumber = dto.PartNumber,
                    GroupID = dto.GroupID,
                    Cavity = dto.Cavity ?? 0,
                    CycleTime = dto.CycleTime ?? 0,
                    Description = dto.Description,
                    PartPrice = dto.PartPrice ?? 0,
                    ScrapPrice = dto.ScrapPrice ?? 0,
                    CustomerId = customerId.Value,

                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = accountId,
                    LastModifiedBy = accountId,
                    LastModifiedAt = DateTime.UtcNow,

                    IsDelete = false,
                    Status = true
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
                response.Message = $"Error adding part: {ex.InnerException?.Message ?? ex.Message}";
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
                    return response;
                }

                existingPart.PartNumber = dto.PartNumber ?? existingPart.PartNumber;
                existingPart.GroupID = dto.GroupID ?? existingPart.GroupID;
                existingPart.Cavity = dto.Cavity ?? existingPart.Cavity;
                existingPart.CycleTime = dto.CycleTime ?? existingPart.CycleTime;
                existingPart.Description = dto.Description ?? existingPart.Description;
                existingPart.PartPrice = dto.PartPrice ?? existingPart.PartPrice;
                existingPart.ScrapPrice = dto.ScrapPrice ?? existingPart.ScrapPrice;

                existingPart.LastModifiedBy = _currentUserService.AccountId;
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

                part.IsDelete = true;
                part.LastModifiedBy = _currentUserService.AccountId;
                part.LastModifiedAt = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Part marked as deleted successfully";
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
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error retrieving part: {ex.Message}";
            }

            return response;
        }
    }
}