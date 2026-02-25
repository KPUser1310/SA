using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;
using System.Text;

namespace SmartAttend.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<UserResponseDto>
    {
        public CreateUserDto User { get; set; }
        public string Password { get; set; }
        public string Base64Image { get; set; }
    }
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, UserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public CreateUserCommandHandler(
            IApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<UserResponseDto> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            var response = new UserResponseDto();
            try
            {
                // 1. Email check
                var emailExists = await _context.Accounts.AnyAsync(x => x.EmailAddress == request.User.EmailAddress && (x.IsDelete == null || x.IsDelete == false),cancellationToken);

                if (emailExists)
                {
                    response.IsSuccess = false;
                    response.Message = "Email already exist";
                    return response;
                }

                //// 2. Image save
                //string imagePath = null;
                //if (!string.IsNullOrEmpty(request.Base64Image))
                //{
                //    var imageName = $"{Guid.NewGuid()}.png";
                //    var folderPath = Path.Combine(
                //        _configuration["DevSite"],
                //        "Images/profile");

                //    Directory.CreateDirectory(folderPath);

                //    var fullPath = Path.Combine(folderPath, imageName);
                //    await File.WriteAllBytesAsync(
                //        fullPath,
                //        Convert.FromBase64String(request.Base64Image),
                //        cancellationToken);

                //    imagePath = "/images/profile/" + imageName;
                //}

                var account = new Account
                {
                    CustomerId = request.User.CustomerId,
                    UserRoleId = request.User.UserRoleId,
                    ContactPerson = $"{request.User.FirstName} {request.User.LastName}".Trim(),
                    FirstName = request.User.FirstName?.Trim(),
                    LastName = request.User.LastName,
                    Status = request.User.Status,
                    ContactNo = request.User.ContactNo,
                    EmailAddress = request.User.EmailAddress,
                    Password = Encrypt(request.Password),
                    Image = string.Empty,
                    IsTempPassword = true,
                    IsEmailNotification = request.User.IsEmailNotification,
                    CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                    LastModifiedAt = null,
                    VacationDateFrom = NormalizeFrom(request.User.VacationDateFrom),
                    VacationDateTo = NormalizeTo(request.User.VacationDateTo)
                };
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync(cancellationToken);
                response.IsSuccess = true;
                response.Message = "User Created Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
        private static string Encrypt(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
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
