using Blog.Models.Entities;
using System.ComponentModel;

namespace Blog.Models.ViewModels
{
    public class PostListViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Excerpt { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        [DisplayName(nameof(Category))]
        public string CategoryName { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; }

        public string? HeaderImageUrl { get; set; }

        public List<string>? Tags { get; set; }

        public int ShareCount { get; set; }
    }
}