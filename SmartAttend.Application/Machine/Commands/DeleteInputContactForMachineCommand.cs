using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Machine.Commands
{
    public class DeleteInputContactForMachineCommand : IRequest<bool>
    {
        public long DeviceUserMapId { get; set; }
    }


    public class DeleteInputContactForMachineCommandHandler : IRequestHandler<DeleteInputContactForMachineCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        private readonly ICurrentUserService _currentUserService;
        public DeleteInputContactForMachineCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Handle(DeleteInputContactForMachineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deviceDataUserMapDetails = await _context.DeviceDataUserMaps
                    .Where(x => x.DeviceDataUserMapId == request.DeviceUserMapId && !x.IsDelete).FirstOrDefaultAsync(cancellationToken);

                if(deviceDataUserMapDetails == null) 
                    return false;

                deviceDataUserMapDetails.IsDelete = true;
                deviceDataUserMapDetails.LastModifiedAt = DateTime.UtcNow;
                deviceDataUserMapDetails.LastModifiedBy = _currentUserService.AccountId;

                _context.DeviceDataUserMaps.Update(deviceDataUserMapDetails);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
