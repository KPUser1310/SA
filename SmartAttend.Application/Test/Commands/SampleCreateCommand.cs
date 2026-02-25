using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Resource;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Test.Commands
{
    public class SampleCreateCommand : IRequest<bool>
    {
        public string EmailId { get; set; }
    }

    public class SampleCreateCommandHandler : IRequestHandler<SampleCreateCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        private readonly IDapperConnectionFactory _dapperContext;

        private readonly ICurrentUserService _currentUserService;
        public SampleCreateCommandHandler(IApplicationDbContext context,
              IDapperConnectionFactory dapperContext,
              ICurrentUserService currentUserService)
        {
            _context = context;
            _dapperContext = dapperContext;
            _currentUserService = currentUserService;
        }
        public async Task<bool> Handle(SampleCreateCommand request, CancellationToken cancellationToken)
        {
            //need to write the logic here           

            var userRolesDetails = await _context.UserRole.AsNoTracking().ToListAsync(cancellationToken);

            using var connection = _dapperContext.CreateConnection();
            IEnumerable<UserRole> userRoles = await connection.QueryAsync<UserRole>(TestSql.TextFile1, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
