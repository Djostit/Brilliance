namespace Brilliance.Domain.Models
{
    public class Pagination<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Page Page { get; set; }
    }
}
