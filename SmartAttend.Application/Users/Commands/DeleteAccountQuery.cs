using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Enums;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Application.Users.Commands
{
    public class DeleteAccountQuery : IRequest<UserResponseDto>
    {
        public int AccountId { get; set; }
    }
    public class DeleteAccountQueryHandler : IRequestHandler<DeleteAccountQuery, UserResponseDto>
    {
        private readonly IApplicationDbContext _context;
        public DeleteAccountQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserResponseDto> Handle(DeleteAccountQuery request, CancellationToken cancellationToken)
        {
            var response = new UserResponseDto();
            try
            {
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
                        x.CustomerId == account.CustomerId &&
                        x.UserRoleId == adminRoleId &&
                        (x.IsDelete == false || x.IsDelete == null),
                        cancellationToken);

                if (account.UserRoleId != adminRoleId || activeAdminCount > 1)
                {
                    // apply soft delete
                    SoftDelete(account);
                    _context.Accounts.Update(account);
                    await _context.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;
                    response.Message = "Deleted Successfully";
                }
                // If Admin → allow only if more than one Admin exists
                else if (activeAdminCount > 1)
                {
                    SoftDelete(account);
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
        private static void SoftDelete(Account account)
        {
            account.Status = false;
            account.IsDelete = true;
            account.LastModifiedAt = DateTime.UtcNow;

        }
    }
}
