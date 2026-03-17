using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartAttend.Application.Common.Enums;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Users.Commands
{
    public class DeleteAccountCommand : IRequest<DeleteUserResponseDto>
    {
        public int AccountId { get; set; }
    }
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeleteUserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService; 
        public DeleteAccountCommandHandler(IApplicationDbContext context,
                        ICurrentUserService currentUserService) 

        {
            _context = context;
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService)); 

        }
        public async Task<DeleteUserResponseDto> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserResponseDto();
            try
            {
                var customerId = _currentUserService.CustomerId;
                var accountId = _currentUserService.AccountId;

                if (!customerId.HasValue || customerId.Value == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "CustomerId could not be resolved from user context.";
                    return response;
                }

                var account = await _context.Accounts
                    .FirstOrDefaultAsync(x => x.AccountId == request.AccountId, cancellationToken);

                if (account == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    return response;
                }

                var adminRoleId = (int)UserRoles.Admin;

                var activeAdminCount = await _context.Accounts
                    .CountAsync(x =>
                        x.CustomerId == customerId.Value &&
                        x.UserRoleId == adminRoleId &&
                        x.IsDelete == false,
                        cancellationToken);

                if (account.UserRoleId != adminRoleId || activeAdminCount > 1)
                {
                    // apply soft delete
                    SoftDelete(account, accountId);
                    _context.Accounts.Update(account);
                    await _context.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;
                    response.Message = "Deleted Successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Deleted not Successfully";
                }
            }
            catch
            {
                throw;
            }
            return response;
        }
        private static void SoftDelete(Account account, int? accountId) 
        {
            account.Status = false;
            account.IsDelete = true;
            account.LastModifiedBy = accountId;  
            account.LastModifiedAt = DateTime.UtcNow;

        }
    }
}
