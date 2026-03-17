

namespace SmartAttend.Application.Common.DTOs
{
    public class UserInfo
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public UserRoleType Role { get; set; }
        public int? CustomerId { get; set; }

    }

    public enum UserRoleType
    {
        Admin = 1,
        Customer = 3,
        Operator = 5
    }

}
