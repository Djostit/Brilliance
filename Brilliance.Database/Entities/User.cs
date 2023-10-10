namespace Brilliance.Database.Entities;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual UserRole Role { get; set; } = null!;
}
