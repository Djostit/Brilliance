using Brilliance.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Brilliance.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly BrillianceContext _context;
        public AccountService(BrillianceContext context)
            => _context = context;
        public async Task<string> Authorization(string username, CancellationToken cancellationToken)
            => (await _context.Users.Include(x => x.IdRoleNavigation).FirstAsync(u => u.Username == username, cancellationToken)).IdRoleNavigation.Name;
    }
}
