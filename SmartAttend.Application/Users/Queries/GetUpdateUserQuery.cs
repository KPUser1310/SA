using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.Application.Users.Queries
{
    public class GetUpdateUserQuery : IRequest<UpdateUserResponseDto>
    {
        public int AccountId { get; set; }
    }
    public class GetUpdateUserQueryHandler: IRequestHandler<GetUpdateUserQuery, UpdateUserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public GetUpdateUserQueryHandler(IApplicationDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<UpdateUserResponseDto> Handle(GetUpdateUserQuery request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserResponseDto();
            try
            {
                var siteUrl = _configuration["Site"];
                var account = await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.AccountId == request.AccountId,cancellationToken);

                if (account == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    response.Response = new UpdateUserDto();
                    return response;
                }

                response.IsSuccess = true;
                response.Message = "Get User Detail";
                response.Response = new UpdateUserDto
                {
                    AccountId = account.AccountId,
                    CustomerId = account.CustomerId ?? 0,
                    UserRoleId = account.UserRoleId,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    EmailAddress = account.EmailAddress,
                    ContactNo = account.ContactNo,
                    Status = account.Status,
                    IsEmailNotification = account.IsEmailNotification,
                    VacationDateFrom = account.VacationDateFrom,
                    VacationDateTo = account.VacationDateTo,
                    IsVocationMode = account.IsVocationMode ?? false,
                    IsDelete = account.IsDelete ?? false,
                    Image = string.IsNullOrEmpty(account.Image)
                        ? string.Empty
                        : siteUrl + account.Image
                };
            }
            catch
            {
                throw;
            }
            return response;
        }
    }
}
