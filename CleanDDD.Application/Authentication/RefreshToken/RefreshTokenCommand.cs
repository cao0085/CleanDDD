using MediatR;

namespace CleanDDD.Application.Authentication.RefreshToken;

public sealed record RefreshTokenCommand(string RefreshToken) : IRequest<(string accessToken, string refreshToken)>;
