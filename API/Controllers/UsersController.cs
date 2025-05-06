using ApplicationLayer.ACommen.Users;
using ApplicationLayer.Users.Commands.CreateUsers;
using ApplicationLayer.Users.Queries;
using ApplicationLayer.Users.Queries.UsersLogin;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(new TokenDto { TokenValue = result.Data! });
        }



        [HttpPost("logIn")]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery loginQuery)
        {
            var result = await _mediator.Send(loginQuery);

            if (!result.IsSuccess)
            {
                return Unauthorized(result); // or BadRequest depending on your logic
            }

            return Ok(new TokenDto { TokenValue = result.Data });
        }

    }
}
