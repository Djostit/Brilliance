using Brilliance.Domain.Models;

namespace Brilliance.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task<string> Authorization(string username, CancellationToken cancellationToken);
        public Task CreateUser(User user, CancellationToken cancellationToken);
        public Task UpdateUser(User user, CancellationToken cancellationToken);
        public Task DeleteUser(int id, CancellationToken cancellationToken);
        public Task<User> GetUser(int id, CancellationToken cancellationToken);
        public Task<Pagination<User>> GetUsers(int page, int size, CancellationToken cancellationToken);
        public Task<bool> IsExists(int id, CancellationToken cancellationToken);
        public Task<bool> IsExistsUsername(string username, CancellationToken cancellationToken);
        public Task<bool> IsExistsSelfUsername(int id, string username, CancellationToken cancellationToken);
    }
}
