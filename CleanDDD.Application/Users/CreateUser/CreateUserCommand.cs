using MediatR;

namespace CleanDDD.Application.Users.CreateUser
{
    public record CreateUserCommand(
        string Name,
        string Password, // 明文密碼，進來後再進行 Hash
        int Type,
        string Nickname,
        string? Email,
        byte State
    ) : IRequest<bool>;
}
