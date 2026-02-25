
namespace SmartAttend.Application.Users.DTOs
{
    public class CreateUserDto
    {
        public int CustomerId { get; set; }
        public int UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public bool Status { get; set; }
        public bool IsEmailNotification { get; set; }
        public DateTime? VacationDateFrom { get; set; }
        public DateTime? VacationDateTo { get; set; }
    }

}
