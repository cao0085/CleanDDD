using MediatR;

namespace CleanDDD.Application.Authentication.LoginUser;

public sealed record LoginUserCommand(string Username, string Password) : IRequest<(string accessToken, string refreshToken)>;
