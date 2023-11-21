namespace Brilliance.Domain.Models.Requests.ById
{
    public class UserRequestById
    {
        public int Id { get; set; } 
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
