using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Parts.DTOs;

namespace SmartAttend.Application.Interfaces
{
    public interface IPartService
    {
        Task<PartResponseModel> GetPartListAsync();
        Task<PartResponseModel> UpdatePartAsync(UpdatePartDtos dto);
        Task<PartResponseModel> AddPartAsync(PartDtos dto);
        Task<PartResponseModel> RemovePartAsync(int id);
        Task<PartResponseModel> GetPartByIdAsync(int id);
    }
}
