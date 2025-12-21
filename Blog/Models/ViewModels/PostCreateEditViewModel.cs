using Blog.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class PostCreateEditViewModel
    {
        public int? Id { get; set; }

        [Required, StringLength(300)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public PostStatus Status { get; set; } = PostStatus.Draft;
        public PostPriority Priority { get; set; } = PostPriority.Normal;

        public DateTime? Deadline { get; set; }

        public string? HeaderImageUrl { get; set; }
        public IFormFile? HeaderImageFile { get; set; }
        [Display(Name = "Remove current header image?")]
        public bool RemoveHeaderImage { get; set; } = false;

        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }

        public ICollection<int> SelectedTagIds { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? Tags { get; set; }
    }
}