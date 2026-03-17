
namespace SmartAttend.Application.Users.DTOs
{

    public class GetUsersListResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetUsersListDto> ResponseList { get; set; }
    }

    public class GetUsersListDto
    {
        public int AccountId { get; set; }
        public int UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }

    }
}
