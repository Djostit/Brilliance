using Brilliance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Brilliance.API.Services
{
    public class PostService : IPostService
    {
        private readonly BrillianceContext _context;
        public PostService(BrillianceContext context)
        {
            _context = context;
        }
        public async Task AddPost(Post post, CancellationToken cancellationToken = default)
        {
            await _context.Posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePost(int id, CancellationToken cancellationToken = default)
        {
            var post = await _context.Posts.FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<Post> GetPost(int id, CancellationToken cancellationToken = default)
        {
            return _context.Posts.Include(x => x.Comments).FirstAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Pagination<Post>> GetPosts(int page, int size, string sort, CancellationToken cancellationToken = default)
        {
            var query = _context.Posts.AsQueryable();
            return new Pagination<Post>()
            {
                Items = await query
                .OrderBy(x => sort == "asc" ? x.Id : -x.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(cancellationToken),
                Page = new Page
                {
                    CurrentPage = page,
                    Size = size,
                    TotalCount = await query.CountAsync(cancellationToken)
                }
            };
        }

        public async Task<bool> IsExists(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Posts.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
