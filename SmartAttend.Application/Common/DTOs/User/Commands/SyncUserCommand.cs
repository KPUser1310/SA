using MediatR;

namespace SmartAttend.Application.Common.DTOs.User.Commands
{
    public class SyncUserCommand : IRequest<UserLoginResponseDto>
    {
    }
}
