using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;


namespace SmartAttend.Application.Notifications.Queries
{
    public class GetOperatorNotificationListByIdQuery :  IRequest<List<OperatorDashBoardResponse>>
    {
        public int AccountId { get; set; }
    }

    public class GetAllOperatorNotificationHandler : IRequestHandler<GetOperatorNotificationListByIdQuery, List<OperatorDashBoardResponse>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllOperatorNotificationHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<OperatorDashBoardResponse>> Handle(GetOperatorNotificationListByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
               List<OperatorDashBoardResponse> response = new List<OperatorDashBoardResponse>();

                var notificationDetails = await (from note in _context.Notifications.AsNoTracking()
                                          where note.AccountId == request.AccountId && note.IsNotify == false
                                          group note by note.DeviceId into g
                                          select g.OrderByDescending(t => t.UpdatedDate).FirstOrDefault()).ToListAsync();

                if (!notificationDetails.Any())
                {
                    return new List<OperatorDashBoardResponse>();
                }

                var deviceIds = notificationDetails.Select(x => x.DeviceId).ToArray();

                var deviceDataUserMapIds = notificationDetails.Select(x => x.DeviceDataUserMapId).ToArray();

                var deviceDetails = await _context.Devices.AsNoTracking()
                    .Where(x => deviceIds.Contains(x.DeviceId))
                    .Select(y => new Device
                    {
                        DeviceId = y.DeviceId,
                        DeviceName = y.DeviceName
                    }).ToListAsync();

                var deviceDataUserMapDetails = await _context.DeviceDataUserMaps.AsNoTracking()
                    .Where(x=> deviceDataUserMapIds.Contains(x.DeviceDataUserMapId))
                    .Select(x=>new DeviceDataUserMaps
                    {
                        DeviceDataUserMapId = x.DeviceDataUserMapId,
                        IsShutdown = x.DeviceDataMap.Input == "Input7" ? 1 : 0
                    }).ToListAsync();

                foreach (var item in notificationDetails)
                {
                    OperatorDashBoardResponse result = new OperatorDashBoardResponse();
                    result.NotificationId = item.Id;
                    result.RunningStatus = 0;
                    result.AccountId = item.AccountId;
                    result.Description = item.Message;

                    var device = deviceDetails.Where(x => x.DeviceId == item.DeviceId).FirstOrDefault();
                    result.DeviceId = device.DeviceId;
                    result.DeviceName = device.DeviceName;
                    result.InputName = item.InputName;
                    result.InputId = item.DeviceDataUserMapId == null ? 0 : item.DeviceDataUserMapId;
                    var deviceIsShutdown = deviceDataUserMapDetails.Where(x => x.DeviceDataUserMapId == item.DeviceDataUserMapId).FirstOrDefault();
                    result.IsShutdown = deviceIsShutdown != null ? deviceIsShutdown.IsShutdown : 0;
                    result.CreatedDate = item.CreatedDate.ToString()!;
                    response.Add(result);
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }

}
