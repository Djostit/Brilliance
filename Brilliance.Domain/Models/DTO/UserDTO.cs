namespace Brilliance.Domain.Models.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; } = null;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
