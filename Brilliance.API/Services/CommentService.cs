namespace Brilliance.API.Services
{
    public class CommentService : ICommentService
    {
        private readonly BrillianceContext _context;
        public CommentService(BrillianceContext context)
        {
            _context = context;
        }
        public async Task AddComment(Comment comment, CancellationToken cancellationToken = default)
        {
            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteComment(int id, CancellationToken cancellationToken = default)
        {
            var comment = await _context.Comments.FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<bool> IsExists(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Comments.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
