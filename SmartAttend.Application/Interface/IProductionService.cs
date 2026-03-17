using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Parts.DTOs;
using SmartAttend.Application.Production.DTOs;
using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Interface
{
    public interface IProductionService
    {
        Task<AssignedPartsResponseModel> GetAssignedPartsAsync();
        Task<AssignedPartsResponseModel> UpdateAssignedPartAsync(UpdateAssignedPartDtos dto, CancellationToken cancellationToken);
        Task<AddScrapResponseDto> AddScrapAsync(AddScrapDto dto);
    }
}
