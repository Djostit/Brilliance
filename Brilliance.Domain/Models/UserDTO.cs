namespace Brilliance.Domain.Models
{
    public record UserDTO
    {
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
