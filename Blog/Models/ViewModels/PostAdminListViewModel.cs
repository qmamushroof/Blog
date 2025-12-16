using Blog.Models.Enums;

namespace Blog.Models.ViewModels
{
    public class PostAdminListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Excerpt { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public Status Status { get; set; }
        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }

        public DateTime? Deadline { get; set; }

        public string? HeaderImageUrl { get; set; }

        public List<string>? Tags { get; set; }

        public int ShareCount { get; set; }
    }
}
