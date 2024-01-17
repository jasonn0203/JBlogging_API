using System;
using System.Collections.Generic;

namespace JBlogging_API.Models;

public partial class ArticleImage
{
    public int ImageId { get; set; }

    public string Image { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long ArticleId { get; set; }

    public virtual Article Article { get; set; } = null!;
}
