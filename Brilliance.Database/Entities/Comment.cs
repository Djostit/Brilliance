using Brilliance.Database.Entities.Base;
using Brilliance.Database.Entities.Base.Interface;
using System;
using System.Collections.Generic;

namespace Brilliance.Database.Entities;

public partial class Comment : Entity
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Post> IdPosts { get; set; } = new List<Post>();
}
