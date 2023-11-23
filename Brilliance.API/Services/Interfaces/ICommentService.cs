namespace Brilliance.API.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentDTO> AddComment(Comment comment, CancellationToken cancellationToken = default);
        public Task DeleteComment(int id, CancellationToken cancellationToken = default);
        public Task<bool> IsExists(int id, CancellationToken cancellationToken = default);
    }
}
