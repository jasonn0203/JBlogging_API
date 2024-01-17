using System;
using System.Collections.Generic;

namespace JBlogging_API.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CateName { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public int Ordering { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
