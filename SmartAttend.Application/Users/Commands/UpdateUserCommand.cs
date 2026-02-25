using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Enums;
using SmartAttend.Application.Common.Inferfaces;

namespace SmartAttend.Application.Users.Commands
{

    public class UpdateUserCommand : IRequest<UserResponseDto>
    {
        public UserDto User { get; set; }
        public string Password { get; set; }
    }
    public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, UserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UserResponseDto();
            try
            {
                var model = request.User;
                var result = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == model.AccountId, cancellationToken);

                if (result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Updated Not Successfully";
                    return response;
                }

                // ROLE ID = 2 Admin check
                var adminRoleId = (int)UserRoles.Admin;
                // Count current admins for the customer
                var adminCount = await _context.Accounts.CountAsync(x => x.CustomerId == model.CustomerId && x.UserRoleId == adminRoleId, cancellationToken);
                
                if (result.UserRoleId == adminRoleId && model.UserRoleId != adminRoleId)
                {
                    adminCount--;
                }

                // EMAIL DUPLICATE CHECK
                int emailCount;

                if (result.EmailAddress == model.EmailAddress)
                {
                    emailCount = await _context.Accounts.CountAsync(x => x.EmailAddress == model.EmailAddress && x.IsDelete == false, cancellationToken);
                    if (emailCount == 1) emailCount = 0;
                }
                else
                {
                    emailCount = await _context.Accounts.CountAsync(x => x.EmailAddress == model.EmailAddress && x.IsDelete == false, cancellationToken);
                }

                if (emailCount >= 1)
                {
                    response.IsSuccess = false;
                    response.Message = "Email alreary exist";
                    return response;
                }

                // Role ID SAFETY RULE
                // ROLE SAFETY RULE: at least one Admin must exist
                if (result.UserRoleId == adminRoleId && adminCount < 1)
                {
                    response.IsSuccess = false;
                    response.Message = "At least one Admin must exist for the customer";
                    return response;
                }

                result.CustomerId = model.CustomerId;
                result.UserRoleId = model.UserRoleId;
                result.FirstName = model.FirstName?.Trim();
                result.LastName = model.LastName;
                result.ContactNo = model.ContactNo;
                result.EmailAddress = model.EmailAddress;
                result.Status = model.Status;
                result.IsVocationMode = model.IsVocationMode;
                result.IsEmailNotification = model.IsEmailNotification;
                result.Image = model.Image;
                result.IsTempPassword = model.IsTempPassword;
                result.LastModifiedAt = DateTime.UtcNow;
                result.VacationDateFrom = NormalizeFrom(model.VacationDateFrom);
                result.VacationDateTo = NormalizeTo(model.VacationDateTo);

                await _context.SaveChangesAsync(cancellationToken);
                // VACATION MODE EFFECT
                if (model.IsVocationMode)
                {
                    var notifications = await _context.Notifications.Where(x => x.AccountId == model.AccountId && x.IsActive == true).ToListAsync(cancellationToken);

                    if (notifications.Count > 0)
                    {
                        notifications.ForEach(n => n.IsActive = false);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                }
                response.IsSuccess = true;
                response.Message = "Updated Successfully";
            }
            catch
            {
                throw;
            }
            return response;
        }
        // DATE NORMALIZATION
        private static DateTime? NormalizeFrom(DateTime? input)
        {
            if (!input.HasValue) return null;
            var date = input.Value.Date.AddHours(12); // 12:00 
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }
        private static DateTime? NormalizeTo(DateTime? input)
        {
            if (!input.HasValue) return null;
            var date = input.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }
    }
}
