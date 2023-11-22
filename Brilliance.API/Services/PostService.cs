using Brilliance.Domain.Models;

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

        public async Task<PostDTO> GetPost(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Posts
                .Include(x => x.Comments)
                .Select(x => new PostDTO
                {
                    Id = x.Id,
                    IdUser = x.IdUser,
                    IdCategory = x.IdCategory,
                    Title = x.Title,
                    Description = x.Description,
                    Date = x.Date,
                    Comments = x.Comments.Select(x => new CommentDTO
                    {
                        Id = x.Id,
                        Username = x.IdUserNavigation.Username,
                        Name = x.Name
                    }).ToList()
                }).FirstAsync(x => x.Id == id, cancellationToken);
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
