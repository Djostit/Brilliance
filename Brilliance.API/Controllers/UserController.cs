using Brilliance.API.Commands.AddEntity;
using Brilliance.API.Commands.DeleteEntity;
using Brilliance.API.Commands.EditEntity;
using Brilliance.API.Queris.Another;
using Brilliance.API.Services.Interfaces;
using Brilliance.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

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

        /// <summary>
        /// Авторизация пользователя 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization(UserDTO userDTO)
            => Ok(await _mediator.Send(new AuthorizationQuery { Username = userDTO.Username, Password = userDTO.Password }));

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            await _mediator.Send(new AddUserCommand(userDTO.Username, userDTO.Password));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            await _mediator.Send(new EditUserCommand(userDTO.Id, userDTO.Username, userDTO.Password));
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => Ok(await _mediator.Send(new GetDataQuery<UserDTO, User>()));
    }
}
