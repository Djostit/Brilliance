using System;
using System.Collections.Generic;

namespace Brilliance.Database.Entities;

public partial class Post
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdCategory { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
