namespace Brilliance.API.Client
{
    public interface IUser
    {
        [Post("/authorization")]
        Task<string> Authorization([Body] UserDTO userDTO);

        [Post("")]
        Task CreateUser([Body] UserDTO userDTO);
    }
}
