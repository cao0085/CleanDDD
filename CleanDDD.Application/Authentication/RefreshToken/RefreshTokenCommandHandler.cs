using CleanDDD.Application.Authentication.LoginUser;
using CleanDDD.Application.Shared;
using MediatR;

namespace CleanDDD.Application.Authentication.RefreshToken
{
    public sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, (string accessToken, string refreshToken)>
    {
        private readonly IAuthenticationService _keycloakAuthService;

        public RefreshTokenCommandHandler(IAuthenticationService keycloakAuthService)
        {
            _keycloakAuthService = keycloakAuthService;
        }

        public async Task<(string accessToken, string refreshToken)> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            (string accessToken, string refreshToken) tokens = await _keycloakAuthService
                .RefreshAccessTokenAsync(request.RefreshToken);

            return tokens;
        }
    }
}
