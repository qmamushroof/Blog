using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        [Required]
        [StringLength(300)]
        public string? Title { get; set; }
        public string? Slug { get; set; }

        [Required]
        public string? Content { get; set; }
        public string? Author { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}