using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.Application.Users.Queries
{
    public class GetUserListQuery : IRequest<UserResponseDto>
    {
        public int CustomerId { get; set; }
    }
    public class GetUserListQueryHandler: IRequestHandler<GetUserListQuery, UserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public GetUserListQueryHandler(
            IApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<UserResponseDto> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var response = new UserResponseDto();
            try
            {
                var siteUrl = _configuration["Site"];
                var users = await _context.Accounts.AsNoTracking()
                    .Where(x =>x.CustomerId == request.CustomerId && (x.IsDelete == false || x.IsDelete == null))
                     .OrderBy(x => x.UserRoleId)
                     .ThenBy(x => x.FirstName)
                     .Select(x => new UserDto
                     {
                         AccountId = x.AccountId,
                         CustomerId = x.CustomerId ?? 0,
                         UserRoleId = x.UserRoleId,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         EmailAddress = x.EmailAddress,
                         ContactNo = x.ContactNo,
                         Status = x.Status,
                         IsEmailNotification = x.IsEmailNotification,
                         VacationDateFrom = x.VacationDateFrom,
                         VacationDateTo = x.VacationDateTo,
                         Image = string.IsNullOrEmpty(x.Image)
                             ? string.Empty
                             : siteUrl + x.Image
                     })
                     .ToListAsync(cancellationToken);
                response.IsSuccess = true;
                response.Message = "AccountList Records";
                response.ResponseList = users;
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
