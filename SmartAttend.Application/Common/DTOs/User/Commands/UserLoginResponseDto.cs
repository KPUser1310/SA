

namespace SmartAttend.Application.Common.DTOs.User.Commands
{
    public class UserLoginResponseDto
    {
        public int AccountId { get; set; }
        public int? CustomerId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public bool IsTempPassword { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
