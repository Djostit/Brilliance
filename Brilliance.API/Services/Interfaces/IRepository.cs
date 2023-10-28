using Brilliance.Domain.Models;

namespace Brilliance.API.Services.Interfaces
{
    public interface IRepository<T>
    {
        abstract IQueryable<T> Items { get; }
        Task<bool> ExistId(int id, CancellationToken cancellationToken = default);
        Task<bool> Exist(T item, CancellationToken cancellationToken = default);
        Task<int> GetCount(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<Page<T>> GetPage(int page, int size, CancellationToken cancellationToken = default);
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
        Task<T> Add(T item, CancellationToken cancellationToken = default);
        Task<T> Update(T item, CancellationToken cancellationToken = default);
        Task<T> Delete(T item, CancellationToken cancellationToken = default);
        Task<T> DeleteById(int id, CancellationToken cancellationToken = default);
    }

    public interface IPage<out T>
    {
        IEnumerable<T> Items { get; }
        int TotalCount { get; }
        int PageIndex { get; }
        int Size { get; }
        int TotalPages { get; }
    }
}
