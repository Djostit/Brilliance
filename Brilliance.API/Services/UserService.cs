using Brilliance.API.Services.Interfaces;
using Brilliance.Domain.Models;
using Brilliance.Domain.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Brilliance.API.Services
{
    public class UserService : IUserService
    {
        private readonly BrillianceContext _context;
        public UserService(BrillianceContext context)
            => _context = context;
        public async Task<string> Authorization(string username, CancellationToken cancellationToken)
            => (await _context.Users.Include(x => x.IdRoleNavigation).FirstAsync(u => u.Username == username, cancellationToken)).IdRoleNavigation.Name;
        public async Task CreateUser(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateUser(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            _context.Users.Remove(await _context.Users.FindAsync(id, cancellationToken));
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<User> GetUser(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(id, cancellationToken);
        }
        public async Task<Pagination<User>> GetUsers(int page, int size, CancellationToken cancellationToken)
        {
            var foo = _context.Users.AsQueryable();
            return new Pagination<User>
            {
                Items = await foo
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(cancellationToken),
                Page = new Page
                {
                    CurrentPage = page,
                    Size = size,
                    TotalCount = await foo.CountAsync(cancellationToken)
                }
            };
        }
        public async Task<bool> IsExists(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<bool> IsExistsUsername(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.Username == username, cancellationToken);
        }
        public async Task<bool> IsExistsSelfUsername(int id, string username, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.Id != id && x.Username == username, cancellationToken);
        }
    }
}
