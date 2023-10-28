using Brilliance.Database.Entities.Base;
using Brilliance.Database.Entities.Base.Interface;
using System;
using System.Collections.Generic;

namespace Brilliance.Database.Entities;

public partial class Role : Entity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
