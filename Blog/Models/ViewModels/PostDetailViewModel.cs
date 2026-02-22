using Blog.Models.Entities;
using System.ComponentModel;

namespace Blog.Models.ViewModels
{
    public class PostDetailViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? HeaderImageUrl { get; set; }
        public string? Author { get; set; }
        [DisplayName(nameof(Category))]
        public string? CategoryName { get; set; }

        public DateTime? PublishedAt { get; set; }

        public ICollection<string>? Tags { get; set; }

        public int ShareCount { get; set; }
        public string FullUrl { get; set; } = string.Empty;
    }
}