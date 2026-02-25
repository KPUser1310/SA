
namespace SmartAttend.Application.Users.DTOs
{
    public class UserResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<UserDto> ResponseList { get; set; }
        public UserDto Response { get; set; }
    }

    public class UserDto
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public int UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public bool IsEmailNotification { get; set; }
        public DateTime? VacationDateFrom { get; set; }
        public DateTime? VacationDateTo { get; set; }
        public bool IsVocationMode { get; set; }
        public bool IsTempPassword { get; set; }
    }
}
