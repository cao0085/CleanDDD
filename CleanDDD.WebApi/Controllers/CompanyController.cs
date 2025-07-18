using CleanDDD.Application.Authentication.LoginUser;
using CleanDDD.Application.Authentication.RefreshToken;
using CleanDDD.Application.Companies.CreateCompany;
using CleanDDD.Application.Companies.GetCompanyInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanDDD.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Logs in a user and returns an authentication token.
        /// </summary>
        /// <param name="command">Login request containing user credentials.</param>
        /// <returns>Returns the authentication token and user details.</returns>
        [HttpGet()]
        public async Task<IActionResult> GetCompanyInfo([FromQuery] GetCompanyInfoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Refreshes an expired authentication token.
        /// </summary>
        /// <param name="command">Request containing the refresh token.</param>
        /// <returns>Returns a new authentication token.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
