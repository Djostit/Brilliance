namespace Brilliance.Domain.Models
{
    public class Page
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / Size);
    }
}
