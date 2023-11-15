using System;
using System.Collections.Generic;

namespace Brilliance.Database.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdPost { get; set; }

    public string Name { get; set; } = null!;

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
