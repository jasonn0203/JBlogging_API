using System;
using System.Collections.Generic;

namespace JBlogging_API.Models;

public partial class Article
{
    public long ArticleId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Thumbnail { get; set; } = null!;

    public string? Quote { get; set; }

    public bool? IsPopular { get; set; }

    public int ReadingTime { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<ArticleImage> ArticleImages { get; set; } = new List<ArticleImage>();

    public virtual ICollection<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User User { get; set; } = null!;
}
