using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;

public class GetUserProfileQueryHandler
    : IRequestHandler<GetUserProfileQuery, UserProfileDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetUserProfileQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserProfileDto?> Handle(GetUserProfileQuery request,CancellationToken cancellationToken)
    {
        return await _dbContext.Accounts
            .AsNoTracking()
            .Where(x => x.AccountId == request.AccountId)
            .Select(x => new UserProfileDto
            {
                AccountId = x.AccountId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmailAddress = x.EmailAddress,
                UserRoleId = x.UserRoleId,
                CustomerId = x.CustomerId,
                AzureObjectId = x.AzureObjectId
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
