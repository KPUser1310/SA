using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Common.Inferfaces;
using System.Security.Claims;

namespace SmartAttend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ApiControllerBase
    {
        private readonly ICurrentUserService _currentUserService;

        public AuthController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpGet("secure")]
        [ProducesResponseType(typeof(AuthStatusDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Secure()
        {
            var expClaim = User.FindFirst("exp")?.Value;

            DateTime? expiresAt = null;
            int? expiresIn = null;

            if (expClaim != null && long.TryParse(expClaim, out var exp))
            {
                expiresAt = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime;
                expiresIn = (int)(expiresAt.Value - DateTime.UtcNow).TotalSeconds;
            }

            var isMfaSatisfied = User.Claims.Any(c =>
                (c.Type == "amr" ||
                 c.Type == "http://schemas.microsoft.com/claims/authnmethodsreferences") &&
                (c.Value == "mfa" || c.Value == "otp"));

            return Ok(new AuthStatusDto
            {
                IsAuthenticated = _currentUserService.IsAuthenticated,
                IsMfaSatisfied = isMfaSatisfied,
                TokenExpiresAt = expiresAt,
                ExpiresInSeconds = expiresIn,
                Message = "Token validated by Azure"
            });
        }

        [HttpGet("claims")]
        [ProducesResponseType(typeof(IEnumerable<ClaimDto>), StatusCodes.Status200OK)]
        public IActionResult Claims()
        {
            var claims = User.Claims.Select(c => new ClaimDto
            {
                Type = c.Type,
                Value = c.Value ?? string.Empty
                })
                .ToList()
                ?? new List<ClaimDto>();

            return Ok(claims);
        }
    }
}
