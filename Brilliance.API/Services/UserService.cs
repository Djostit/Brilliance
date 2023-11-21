using Brilliance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Brilliance.API.Services
{
    public class UserService : IUserService
    {
        private readonly BrillianceContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(BrillianceContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> GetUserRole(string username, CancellationToken cancellationToken)
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

        public async Task<bool> Authorization(string username, string password, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstAsync(x => x.Username == username, cancellationToken);
            return _passwordHasher.VerifyPassword(user.Password, password);
        }
    }
}
