using Brilliance.Domain.Models;

namespace Brilliance.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task<string> GetUserRole(string username, CancellationToken cancellationToken = default);
        public Task<bool> Authorization(string username, string password, CancellationToken cancellationToken = default);
        public Task CreateUser(User user, CancellationToken cancellationToken = default);
        public Task UpdateUser(User user, CancellationToken cancellationToken = default);
        public Task DeleteUser(int id, CancellationToken cancellationToken = default);
        public Task<int> GetUserId(string username, CancellationToken cancellationToken = default);
        public Task<User> GetUser(int id, CancellationToken cancellationToken = default);
        public Task<Pagination<User>> GetUsers(int page, int size, CancellationToken cancellationToken = default);
        public Task<bool> IsExists(int id, CancellationToken cancellationToken = default);
        public Task<bool> IsExistsUsername(string username, CancellationToken cancellationToken = default);
        public Task<bool> IsExistsSelfUsername(int id, string username, CancellationToken cancellationToken = default);
    }
}
