using Brilliance.Domain.Models.Requests;

namespace Brilliance.API.Client
{
    public interface IPostClient
    {
        [Post("")]
        public Task CreatePost(PostRequest post);
    }
}
