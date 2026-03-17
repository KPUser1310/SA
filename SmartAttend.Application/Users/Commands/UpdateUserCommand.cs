using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartAttend.Application.Common.Enums;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Users.DTOs;

namespace SmartAttend.Application.Users.Commands
{

    public class UpdateUserCommand : IRequest<UpdateUserResponseDto>
    {
        public UpdateUserDto User { get; set; }
        public IFormFile? Image { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserCommandHandler(
            IApplicationDbContext context,
            IConfiguration configuration,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _configuration = configuration;
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }
        public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserResponseDto();
            try
            {
                // ✅ Resolve CustomerId and AccountId from user context
                var customerId = _currentUserService.CustomerId;
                var accountId = _currentUserService.AccountId;

                if (!customerId.HasValue || customerId.Value == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "CustomerId could not be resolved from user context.";
                    return response;
                }

                var model = request.User;
                var result = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == model.AccountId, cancellationToken); // account id from request

                if (result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Updated Not Successfully";
                    return response;
                }

                // ROLE ID = 2 Admin check
                var adminRoleId = (int)UserRoles.Admin;
                // Count current admins for the customer
                var adminCount = await _context.Accounts.CountAsync(x => x.CustomerId == customerId && x.UserRoleId == adminRoleId, cancellationToken);

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
                    response.Message = "Email already exist";
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

                result.CustomerId = customerId.Value;
                result.UserRoleId = model.UserRoleId;
                result.FirstName = model.FirstName.Trim();
                result.LastName = model.LastName;
                result.ContactNo = model.ContactNo;
                result.EmailAddress = model.EmailAddress;
                result.Status = model.Status;
                result.LastModifiedBy = accountId;
                result.LastModifiedAt = DateTime.UtcNow;
                result.VacationDateFrom = NormalizeFrom(model.VacationDateFrom);
                result.VacationDateTo = NormalizeTo(model.VacationDateTo);

                await _context.SaveChangesAsync(cancellationToken);

                // IMAGE UPDATE / REPLACE LOGIC (deletes the exiting one then inserts the new img)
                if (request.Image != null && request.Image.Length > 0)
                {
                    var imageRoot = _configuration.GetValue<string>("ImageStoragePath");

                    var folderPath = Path.Combine(
                         Directory.GetCurrentDirectory(),
                         imageRoot
                     );

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    // DELETE OLD IMAGE IF EXISTS
                    if (!string.IsNullOrWhiteSpace(result.Image))
                    {
                        var oldImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            result.Image.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
                        );

                        if (File.Exists(oldImagePath))
                            File.Delete(oldImagePath);
                    }

                    var extension = Path.GetExtension(request.Image.FileName);

                    var fileName = $"user_profile_{result.AccountId}{extension}";


                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(stream, cancellationToken);
                    }

                    result.Image = $"/{imageRoot}/{fileName}";

                    _context.Accounts.Update(result);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                // WORKING DAYS UPDATE LOGIC (null / empty => clear all)
                {
                    var selectedDays = model.WorkingDays ?? new List<int>();

                    // validate enum values (only if list has items)
                    if (selectedDays.Any(d => !Enum.IsDefined(typeof(Common.Enums.WorkingDays), d)))
                    {
                        response.IsSuccess = false;
                        response.Message = "Invalid working day value";
                        return response;
                    }

                    var existingDays = await _context.WorkingDays
                        .Where(x => x.AccountId == model.AccountId)
                        .ToListAsync(cancellationToken);

                    // SAFETY: if rows don't exist, create all 7
                    if (!existingDays.Any())
                    {
                        var newDays = Enum.GetValues(typeof(Common.Enums.WorkingDays))
                            .Cast<Common.Enums.WorkingDays>()
                            .Select(day => new Domain.Entities.WorkingDays
                            {
                                AccountId = model.AccountId,
                                Days = day.ToString(),
                                IsSelected = selectedDays.Contains((int)day), // null/empty => all false
                                CreatedBy = accountId,
                                CreatedAt = DateTime.UtcNow,
                                LastModifiedBy = accountId,
                                LastModifiedAt = DateTime.UtcNow
                            })
                            .ToList();

                        await _context.WorkingDays.AddRangeAsync(newDays, cancellationToken);
                    }
                    else
                    {
                        foreach (var day in existingDays)
                        {
                            var enumValue = Enum.Parse<Common.Enums.WorkingDays>(day.Days);
                            day.IsSelected = selectedDays.Contains((int)enumValue); // null/empty => false
                            day.LastModifiedAt = DateTime.UtcNow;
                        }
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                }
                response.IsSuccess = true;
                response.Message = "Updated Successfully";
            }
            catch (Exception ex)
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
