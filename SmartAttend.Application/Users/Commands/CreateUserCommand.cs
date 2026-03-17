using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace SmartAttend.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponseDto>
    {
        public CreateUserDto User { get; set; }
        public IFormFile? Image { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService; 

        public CreateUserCommandHandler(
            IApplicationDbContext context,
            IConfiguration configuration,
            ICurrentUserService currentUserService)

        {
            _context = context;
            _configuration = configuration;
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService)); 
        }
        public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateUserResponseDto();
            try
            {

                // ✅ Resolve both CustomerId and AccountId from user context — same as PartService
                var customerId = _currentUserService.CustomerId;
                var accountId = _currentUserService.AccountId;
                var AzureObjectId = _currentUserService.AzureObjectId;


                if (!customerId.HasValue || customerId.Value == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "CustomerId could not be resolved from user context.";
                    return response;
                }

                // 1. Email check
                var emailExists = await _context.Accounts.AnyAsync(x => x.EmailAddress == request.User.EmailAddress && x.IsDelete == false, cancellationToken);

                if (emailExists)
                {
                    response.IsSuccess = false;
                    response.Message = "Email already exist";
                    return response;
                }

                var account = new Account
                {
                    CustomerId = customerId.Value,
                    UserRoleId = request.User.UserRoleId,
                    FirstName = request.User.FirstName.Trim(),
                    LastName = request.User.LastName.Trim(),
                    Status = request.User.Status,
                    ContactNo = request.User.ContactNo,
                    EmailAddress = request.User.EmailAddress,
                    Image = string.Empty, // not null in db
                    IsTempPassword = true,
                    CreatedBy = accountId,
                    CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                    LastModifiedBy = accountId,
                    LastModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                    Password = "********",// its not null column in Accounts 
                    VacationDateFrom = NormalizeFrom(request.User.VacationDateFrom),
                    VacationDateTo = NormalizeTo(request.User.VacationDateTo),
                    IsDelete = false,
                    AzureObjectId= AzureObjectId

                };
                await _context.Accounts.AddAsync(account, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                // IMAGE SAVE LOGIC
                if (request.Image != null && request.Image.Length > 0)
                {
                    var extension = Path.GetExtension(request.Image.FileName);
                    var fileName = $"user_profile_{account.AccountId}{extension}";

                    // Folder structure → Image/
                    var imageRoot = _configuration.GetValue<string>("ImageStoragePath");

                    var folderPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        imageRoot
                    );

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(stream, cancellationToken);
                    }

                    // Save relative path to DB
                    account.Image = $"/{imageRoot}/{fileName}";

                    _context.Accounts.Update(account);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                // WORKING DAYS LOGIC
                if (!request.User.WorkingDays.Any(d => !Enum.IsDefined(typeof(Common.Enums.WorkingDays),(Common.Enums.WorkingDays)d)))
                {
                    var selectedDays = request.User.WorkingDays;

                    var workingDaysEntities = Enum.GetValues(typeof(Common.Enums.WorkingDays))
                        .Cast<Common.Enums.WorkingDays>()
                        .Select(day => new Domain.Entities.WorkingDays
                        {
                            AccountId = account.AccountId,
                            Days = day.ToString(),                 
                            IsSelected = selectedDays.Contains((int)day),
                            CreatedBy= accountId,
                            CreatedAt = DateTime.UtcNow,
                            LastModifiedBy = accountId,
                            LastModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc)
                        })
                        .ToList();

                    await _context.WorkingDays.AddRangeAsync(workingDaysEntities, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                response.IsSuccess = true;
                response.Message = "User Created Successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        private static DateTime? NormalizeFrom(DateTime? input)
        {
            if (!input.HasValue) return null;
            var date = input.Value.Date.AddHours(12); // 12:00 PM
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
