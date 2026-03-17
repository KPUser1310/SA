using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Constant;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.Application.Users.Queries
{
    public class GetUserQuery : IRequest<GetUserResponseDto>
    {
        public int AccountId { get; set; }
    }
    public class GetUpdateUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        public GetUpdateUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetUserResponseDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUserResponseDto();
            try
            {
                var account = await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.AccountId == request.AccountId && x.IsDelete == false, cancellationToken);

                if (account == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    response.Response = new GetUserDto();
                    return response;
                }

                // ✅ FETCH WORKING DAYS
                var workingDaysRaw = await _context.WorkingDays
                                    .AsNoTracking()
                                    .Where(x => x.AccountId == account.AccountId && x.IsSelected)
                                    .Select(x => x.Days)
                                    .ToListAsync(cancellationToken);

                var workingDays = workingDaysRaw
                                    .Select(d =>
                                        Enum.TryParse<Common.Enums.WorkingDays>(d, out var day)
                                            ? (int)day
                                            : 0
                                    )
                                    .Where(x => x > 0)
                                    .OrderBy(x => x)
                                    .ToList();

                response.IsSuccess = true;
                response.Message = "Get User Detail";
                response.Response = new GetUserDto
                {
                    AccountId = account.AccountId,
                    UserRoleId = account.UserRoleId,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    EmailAddress = account.EmailAddress,
                    ContactNo = account.ContactNo,
                    Status = account.Status,
                    VacationDateFrom = account.VacationDateFrom,
                    VacationDateTo = account.VacationDateTo,
                    Image = string.IsNullOrEmpty(account.Image)
                            ? string.Empty
                            : Constant.AdminImageUrl + account.Image,
                    WorkingDays = workingDays
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
