using Blog.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class PostListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Excerpt { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; }

        public string? HeaderImageUrl { get; set; }

        public List<string>? Tags { get; set; }

        public int ShareCount { get; set; }
    }
}
