using Brilliance.Domain.Models;

namespace Brilliance.API.Services.Interfaces
{
    public interface IPostService
    {
        public Task AddPost(Post post, CancellationToken cancellationToken = default);
        public Task DeletePost(int id, CancellationToken cancellationToken = default);
        public Task<PostDTO> GetPost(int id, CancellationToken cancellationToken = default);
        public Task<Pagination<Post>> GetPosts(int page, int size, string sort, int? categoryid, CancellationToken cancellationToken = default);
        public Task<bool> IsExists(int id, CancellationToken cancellationToken = default);
    }
}
