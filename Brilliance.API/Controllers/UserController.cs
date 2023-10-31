using Brilliance.API.Commands.AddEntity;
using Brilliance.API.Queris.GetData;
using Brilliance.API.Services.Interfaces;
using Brilliance.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;
        public UserController(IMediator mediator, IPasswordHasher passwordHasher)
        {
            _mediator = mediator;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization(UserDTO userDTO)
            => Ok(await _mediator.Send(new AuthorizationQuery { Username = userDTO.Username, Password = userDTO.Password }));

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            userDTO.Password = _passwordHasher.HashPassword(userDTO.Password);
            await _mediator.Send(new AddEntityCommand<UserDTO, User>(userDTO));
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => Ok(await _mediator.Send(new GetDataQuery<UserDTO, User>()));
    }
}
