using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base;
using Brilliance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Brilliance.API.Services
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly BrillianceContext _context;
        protected DbSet<T> Set { get; }
        public IQueryable<T> Items => Set;
        public Repository(BrillianceContext context)
        {
            _context = context;
            Set = _context.Set<T>();
        }
        public async Task<T> Add(T item, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(item, cancellationToken);
            await SaveChanges();
            return item;
        }

        public async Task<T> Delete(T item, CancellationToken cancellationToken = default)
        {
            if (!await ExistId(item.Id, cancellationToken)) return null;

            _context.Remove(item);
            await SaveChanges();
            return item;
        }

        public async Task<T> DeleteById(int id, CancellationToken cancellationToken = default)
        {
            var item = Set.Local.FirstOrDefault(x => x.Id == id) ?? await Set
                    .Select(i => new T { Id = i.Id })
                    .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
            if (item is null)
                return null;

            return await Delete(item, cancellationToken);
        }

        public virtual async Task<bool> Exist(T item, CancellationToken cancellationToken = default)
            => await Items.AnyAsync(i => i.Id == item.Id, cancellationToken);

        public async Task<bool> ExistId(int id, CancellationToken cancellationToken = default)
            => await Items.AnyAsync(item => item.Id == id, cancellationToken);

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
            => await Items.ToArrayAsync(cancellationToken);

        public async Task<T> GetById(int id, CancellationToken cancellationToken = default)
            => Items switch
            {
                DbSet<T> set => await set.FindAsync(new object[] { id }, cancellationToken),
                { } items => await items.FirstOrDefaultAsync(item => item.Id == id, cancellationToken),
                _ => throw new Exception()
            };

        public async Task<int> GetCount(CancellationToken cancellationToken = default)
            => await Items.CountAsync(cancellationToken);

        public async Task<Page<T>> GetPage(int page, int size, CancellationToken cancellationToken = default)
        {
            var query = Items;
            var count = await query.CountAsync(cancellationToken);
            var items = await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
            return new Page<T>
            {
                Items = items,
                PageIndex = page,
                Size = size,
                TotalCount = count
            };
        }

        public async Task<T> Update(T item, CancellationToken cancellationToken = default)
        {
            _context.Update(item);
            await SaveChanges();
            return item;
        }

        //protected record Page(IEnumerable<T> Items, int TotalCount, int PageIndex, int Size) : IPage<T>
        //{
        //    public int TotalPages => (int)Math.Ceiling((double)TotalCount / Size);
        //}

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
