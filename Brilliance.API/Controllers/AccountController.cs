using Brilliance.API.Command;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.API.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization(UserDTO userDTO)
            => Ok(await _mediator.Send(new AuthorizationQuery { Username = userDTO.Username, Password = userDTO.Password }));

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            await _mediator.Send(new AddUserCommand
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                RoleId = userDTO.RoleId
            });
            return CreatedAtAction(null, null);
        }
    }
}
