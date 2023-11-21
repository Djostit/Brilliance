using Brilliance.API.Commands.EditEntity;
using Brilliance.Domain.Models.Requests;
using Brilliance.Domain.Models.Requests.ById;

namespace Brilliance.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Авторизация пользователя 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization(UserRequest user)
            => Ok(await _mediator.Send(new AuthorizationQuery(user.Username, user.Password)));

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {
            await _mediator.Send(new AddUserCommand(user.Username, user.Password));
            return Ok();
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRequestById user)
        {
            await _mediator.Send(new EditUserCommand(user.Id, user.Username, user.Password));
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //    => Ok(await _mediator.Send(new GetDataQuery<UserDTO, User>()));
    }
}
