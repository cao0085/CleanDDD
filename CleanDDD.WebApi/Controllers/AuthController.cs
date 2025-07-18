using CleanDDD.Application.Authentication.LoginUser;
using CleanDDD.Application.Authentication.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanDDD.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Logs in a user and returns an authentication token.
        /// </summary>
        /// <param name="command">Login request containing user credentials.</param>
        /// <returns>Returns the authentication token and user details.</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginUserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(
            Summary = "User login",
            Description = "Authenticates the user based on provided credentials and returns a JWT token."
        )]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(new { access_token = response.accessToken, refresh_token = response.refreshToken });
        }

        /// <summary>
        /// Refreshes an expired authentication token.
        /// </summary>
        /// <param name="command">Request containing the refresh token.</param>
        /// <returns>Returns a new authentication token.</returns>
        [Authorize]
        [HttpPost("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RefreshTokenDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(
            Summary = "Refresh authentication token",
            Description = "Generates a new authentication token using a valid refresh token."
        )]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
