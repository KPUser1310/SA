using MediatR;
using SmartAttend.Application.Common.DTOs;

public class GetUserProfileQuery : IRequest<UserProfileDto>
{
    public int AccountId { get; set; }
}