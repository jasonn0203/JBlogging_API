using System;
using System.Collections.Generic;

namespace JBlogging_API.Models;

public partial class ArticleLike
{
    public int ArticleLikeId { get; set; }

    public long ArticleId { get; set; }

    public int UserId { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
