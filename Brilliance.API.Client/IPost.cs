namespace Brilliance.API.Client
{
    public interface IPost
    {
        [Get("/")]
        Task<Page<PostDTO>> GetPosts([AliasAs("page")] int page, [AliasAs("size")] int size);

        [Get("/{id}")]
        Task<PostDTO> GetPost(int id);
    }
}
