namespace Brilliance.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BrillianceContext _context;
        public CategoryService(BrillianceContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDTO>> GetCategories(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.Select(x => new CategoryDTO
            {
                Id  = x.Id,
                Name = x.Name
            }).ToListAsync(cancellationToken);
        }
        public async Task AddCategory(Category category, CancellationToken cancellationToken = default)
        {
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCategory(int id, CancellationToken cancellationToken = default)
        {
            var category = await _context.Categories.FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> IsExists(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id, cancellationToken);
        }
    }
}
