using System.Drawing;

namespace Brilliance.Domain.Models
{
    public class Page<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int Size { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / Size);
    }
}
