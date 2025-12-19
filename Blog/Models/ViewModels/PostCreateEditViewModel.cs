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

        public Status Status { get; set; } = Status.Draft;
        public Priority Priority { get; set; } = Priority.Normal;

        public DateTime? Deadline { get; set; }

        public string? HeaderImageUrl { get; set; }
        public IFormFile? HeaderImageFile { get; set; }

        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }

        public ICollection<int> SelectedTagIds { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? Tags { get; set; }

        [Display(Name = "Remove current header image?")]
        public bool RemoveHeaderImage { get; set; } = false;
    }
}