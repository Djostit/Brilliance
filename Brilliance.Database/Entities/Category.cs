using Brilliance.Database.Entities.Base;
using Brilliance.Database.Entities.Base.Interface;
using System;
using System.Collections.Generic;

namespace Brilliance.Database.Entities;

public partial class Category : Entity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
