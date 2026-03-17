using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Constant;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Machine.DTOs;

namespace SmartAttend.Application.Machine.Queries
{
    public class GetMachineListQuery : IRequest<List<MachineListResponse>>
    {
        public int CustomerId { get; set; }
        public string Search { get; set; }
    }

    public class GetMachineListQueryHandler : IRequestHandler<GetMachineListQuery, List<MachineListResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetMachineListQueryHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<MachineListResponse>> Handle(GetMachineListQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var machineData = await _context.Devices
                    .AsNoTracking()
                    .Where(x => x.CustomerId == request.CustomerId && !x.IsDelete)
                    .Select(x => new
                    {
                        x.Id,
                        x.DeviceId,
                        x.DeviceName,
                        x.Image
                    })
                    .ToListAsync(cancellationToken);


                if (!string.IsNullOrWhiteSpace(request.Search))
                {
                    var searchLower = request.Search.ToLower().Trim();
                    machineData = machineData
                        .Where(x => x.DeviceName.ToLower().Contains(searchLower)
                                 || x.DeviceId.ToString().Contains(searchLower))
                        .ToList();
                }                

                var machineListResponse = machineData
                    .Select(x => new MachineListResponse
                    {
                        Id = x.Id,
                        DeviceId = x.DeviceId,
                        DeviceName = x.DeviceName,
                        Image = GetImageUrl($"{x.Id}_{x.Image}") 
                    })
                    .ToList();

                return machineListResponse;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private string GetImageUrl(string storedPath)
        {
            if (string.IsNullOrEmpty(storedPath))
                return null;

            string fileName = Path.GetFileName(storedPath);

            string imageUrl = $"{Constant.MachineImageUrl}/{fileName}";

            return imageUrl;
        }
    }

}
