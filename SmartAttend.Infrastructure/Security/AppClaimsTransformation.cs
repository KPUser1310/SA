using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SmartAttend.Application.Common.Inferfaces;
using System.Security.Claims;

namespace SmartAttend.Infrastructure.Security
{
    public class AppClaimsTransformation : IClaimsTransformation
    {
        private readonly IApplicationDbContext _dbContext;

        public AppClaimsTransformation(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity is not ClaimsIdentity identity)
                return principal;

            if (identity.HasClaim(c => c.Type == "AccountId"))
                return principal;

            var azureOid =
                principal.FindFirst("oid")?.Value ??
                principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;

            if (string.IsNullOrWhiteSpace(azureOid))
                return principal;

            var email =
                principal.FindFirst(ClaimTypes.Email)?.Value ??
                principal.FindFirst("preferred_username")?.Value;

            var user = await _dbContext.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    u.AzureObjectId != null &&
                    u.AzureObjectId == azureOid &&
                    u.Status == true &&
                    u.IsDelete == false);

            if (user == null && !string.IsNullOrWhiteSpace(email))
            {
                user = await _dbContext.Accounts
                    .FirstOrDefaultAsync(u =>
                        u.EmailAddress == email &&
                        u.Status == true &&
                        u.IsDelete == false);

                if (user != null)
                {
                    user.AzureObjectId = azureOid;
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (user == null)
                return principal;

            identity.AddClaim(new Claim("AccountId", user.AccountId.ToString()));
            identity.AddClaim(new Claim("UserRoleId", user.UserRoleId.ToString()));

            if (user.CustomerId.HasValue)
            {
                identity.AddClaim(new Claim("CustomerId", user.CustomerId.Value.ToString()));
            }

            identity.AddClaim(new Claim("AzureObjectId", azureOid));

            return principal;
        }
    }
}
