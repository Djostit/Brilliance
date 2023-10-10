using Brilliance.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brilliance.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly BrillianceContext _context;
        public AccountService(BrillianceContext context)
            => _context = context;

        public async Task AddUser(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<string> Authorization(string username, CancellationToken cancellationToken)
            => (await _context.Users.FirstAsync(u => u.Username == username, cancellationToken)).RoleId.ToString();

        public Task<List<User>> GetUsers(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAuth(string username, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExist(string username, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
