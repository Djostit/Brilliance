namespace Brilliance.API.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategory(Category category, CancellationToken cancellationToken = default);
        public Task DeleteCategory(int id, CancellationToken cancellationToken = default);
        public Task<bool> IsExists(int id, CancellationToken cancellationToken = default);
    }
}
