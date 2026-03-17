using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Users.DTOs;
using SmartAttend.Application.Common.Constant;

namespace SmartAttend.Application.Users.Queries
{
    public class GetUserListQuery : IRequest<GetUsersListResponseDto>
    {
    }
    public class GetUserListQueryHandler: IRequestHandler<GetUserListQuery, GetUsersListResponseDto>
    {
        private readonly IApplicationDbContext _context;
        
        private readonly ICurrentUserService _currentUserService;
        public GetUserListQueryHandler(
            IApplicationDbContext context,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService)); 
        }
        public async Task<GetUsersListResponseDto> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUsersListResponseDto();
            try
            {
                var customerId = _currentUserService.CustomerId;

                if (!customerId.HasValue || customerId.Value == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "CustomerId could not be resolved from user context.";
                    return response;
                }

                var users = await _context.Accounts.AsNoTracking()

                    .Where(x =>x.CustomerId == customerId && x.IsDelete == false)
                     .OrderBy(x => x.UserRoleId)
                     .ThenBy(x => x.FirstName)
                     .Select(x => new GetUsersListDto
                     {
                         AccountId = x.AccountId,
                         UserRoleId = x.UserRoleId,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         Image = string.IsNullOrEmpty(x.Image)
                             ? string.Empty
                             : Constant.AdminImageUrl + x.Image
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
