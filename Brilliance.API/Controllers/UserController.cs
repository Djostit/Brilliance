using Brilliance.API.Commands.EditEntity;

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
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            await _mediator.Send(new EditUserCommand(userDTO.Id, userDTO.Username, userDTO.Password));
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
