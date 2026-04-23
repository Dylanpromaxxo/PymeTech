using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PymeTech.API.Common;
using PymeTech.Application.Feature.Auth.AuthDTO;
using PymeTech.Application.Feature.Auth.Command.Login;
using PymeTech.Application.Feature.Auth.Command.Register;

namespace PymeTech.API.Controllers
{
    [Route("api/v1/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken) 
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(command, cancellationToken);
            return Ok(ApiResponse<RegisterResponseDto>.Ok(data)); 
            
        }
    }
}
