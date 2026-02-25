using Microsoft.AspNetCore.Http;
using SmartAttend.Application.Common.Inferfaces;
using System.Security.Claims;

namespace SmartAttend.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User =>
            _httpContextAccessor.HttpContext?.User;

        public int AccountId =>
            int.TryParse(User?.FindFirst("AccountId")?.Value, out var id)
                ? id
                : 0;

        public int UserRoleId =>
            int.TryParse(User?.FindFirst("UserRoleId")?.Value, out var roleId)
                ? roleId
                : 0;

        public int? CustomerId =>
            int.TryParse(User?.FindFirst("CustomerId")?.Value, out var customerId)
                ? customerId
                : null;

        public string AzureObjectId =>
            User?.FindFirst("AzureObjectId")?.Value ??
            User?.FindFirst("oid")?.Value ??
            User?.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value ??
            string.Empty;

        public bool IsAuthenticated =>
            User?.Identity?.IsAuthenticated ?? false;
        public string CorrelationId => _httpContextAccessor.HttpContext?
               .Request?.Headers["X-Correlation-ID"].ToString() ?? string.Empty;
    }
}
