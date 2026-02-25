using SmartAttend.Application.Common.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Interfaces
{
    public interface IPartService
    {
        Task<PartResponseModel> GetUpdatePartbyIdAsync(int id);
        Task<PartResponseModel> GetPartListAsync(int customerId);
        Task<PartResponseModel> GetRemovePartAsync(int id);
        Task<PartResponseModel> UpdatePartAsync(AssignedPart model);
        Task<PartResponseModel> AddPartAsync(AssignedPart model);
        Task<PartResponseModel> RemovePartAsync(int id);
        Task<PartResponseModel> GetPartByIdAsync(int id);
    }
}
