using CleanDDD.Application.Shared;
using MediatR;

namespace CleanDDD.Application.Authentication.LoginUser
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, (string accessToken, string refreshToken)>
    {
        private readonly IAuthenticationService _keycloakAuthService;

        public LoginUserCommandHandler(IAuthenticationService keycloakAuthService)
        {
            _keycloakAuthService = keycloakAuthService;
        }

        public async Task<(string accessToken, string refreshToken)> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            (string accessToken, string refreshToken) tokens = await _keycloakAuthService
                .RequestTokenUsingPasswordGrantAsync(request.Username, request.Password);

            return tokens;
        }
    }
}
