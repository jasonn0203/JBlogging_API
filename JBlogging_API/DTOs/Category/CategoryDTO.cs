namespace JBlogging_API.DTOs.Category
{
    public class CategoryDTO
    {
        public string CateName { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;

        public int Ordering { get; set; }

    }
}
