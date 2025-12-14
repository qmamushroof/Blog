using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Content { get; set; }
        public string? Author { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
