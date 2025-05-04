using ApplicationLayer.ACommen.Users;
using ApplicationLayer.Users.Commands.CreateUsers;
using ApplicationLayer.Users.Queries.UsersLogin;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var token = await _mediator.Send(command);
                return Ok(new TokenDto { TokenValue = token });
            }
            catch (Exception ex)
            {
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }

        [HttpPost("logIn")]
        [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserCredentialsDto userToLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                string token = await _mediator.Send(new LoginUserQuery(userToLogin));
                return Ok(new TokenDto { TokenValue = token });
            }
            catch (Exception)
            {
                return Unauthorized("Invalid username or password.");
            }
        }
    }
}
