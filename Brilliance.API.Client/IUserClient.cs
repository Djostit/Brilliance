using Brilliance.Domain.Models.Requests;
using Brilliance.Domain.Models.Requests.ById;

namespace Brilliance.API.Client
{
    public interface IUserClient
    {
        [Post("/authorization")]
        Task<string> Authorization([Body] UserRequest user);

        [Post("")]
        Task CreateUser([Body] UserRequest user);

        [Put("")]
        Task UpdateUser([Body] UserRequestById user);

        [Delete("")]
        Task DeleteUser([AliasAs("id")] int id);
    }
}
