using Brilliance.Database.Entities;

namespace Brilliance.API.IServices
{
    public interface IAccountService
    {
        public Task AddUser(User user, CancellationToken cancellationToken);
        public Task<string> Authorization(string username, CancellationToken cancellationToken);
        public Task<List<User>> GetUsers(CancellationToken cancellationToken);
        public Task<bool> IsExist(string username, CancellationToken cancellationToken);
        public Task<bool> IsAuth(string username, string password, CancellationToken cancellationToken);
    }
}
