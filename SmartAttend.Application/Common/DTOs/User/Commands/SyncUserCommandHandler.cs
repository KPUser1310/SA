using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Common.DTOs.User.Helper;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Common.DTOs.User.Commands
{
    public class SyncUserCommandHandler
        : IRequestHandler<SyncUserCommand, UserLoginResponseDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<SyncUserCommandHandler> _logger;

        public SyncUserCommandHandler(IApplicationDbContext dbContext,ICurrentUserService currentUserService,ILogger<SyncUserCommandHandler> logger)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _logger = logger;
        }

        public async Task<UserLoginResponseDto> Handle(SyncUserCommand request,CancellationToken cancellationToken)
        {
            try
            {
                var email = _currentUserService.Email;
                var azureObjectId = _currentUserService.AzureObjectId;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(azureObjectId))
                {
                    throw new UnauthorizedAccessException("Invalid user identity.");
                }

                var roleId = _currentUserService.UserRoleId;

                if (roleId == 0)
                {
                    roleId = (int)UserRoleType.Operator;
                }

                var customerId = _currentUserService.CustomerId;

                var account = await _dbContext.Accounts
                    .FirstOrDefaultAsync(x =>
                        x.AzureObjectId == azureObjectId &&
                        !x.IsDelete,
                        cancellationToken);

                if (account == null)
                {
                    var assignedCustomerId =
                        roleId == (int)UserRoleType.Operator ? null : customerId;

                    var firstName = _currentUserService.FirstName ?? email.Split('@')[0];
                    var lastName = _currentUserService.LastName ?? string.Empty;

                    account = new Account
                    {
                        EmailAddress = email,
                        FirstName = firstName,
                        LastName = lastName,

                        ContactNo = _currentUserService.PhoneNumber ?? string.Empty,

                        Password = PasswordHelper.GenerateTempPassword(),
                        IsTempPassword = true,

                        UserRoleId = roleId,
                        CustomerId = assignedCustomerId,

                        Status = true,
                        IsDelete = false,

                        Image = string.Empty,
                        IsEmailNotification = true,
                        IsDragAndDrop = false,

                        AzureObjectId = azureObjectId,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = 0
                    };

                    _dbContext.Accounts.Add(account);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    _logger.LogInformation(
                        "New user created. AccountId: {AccountId}, RoleId: {RoleId}, CustomerId: {CustomerId}",
                        account.AccountId,
                        account.UserRoleId,
                        account.CustomerId);
                }

                return new UserLoginResponseDto
                {
                    AccountId = account.AccountId,
                    CustomerId = account.CustomerId,
                    Email = account.EmailAddress,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    RoleId = account.UserRoleId,
                    IsTempPassword = account.IsTempPassword ?? false,
                    Message = "Login successful"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "User sync failed for AzureObjectId {AzureObjectId}",
                    _currentUserService.AzureObjectId);

                throw;
            }
        }
    }
}