using System;
using System.Collections.Generic;

namespace Brilliance.Database.Entities;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
