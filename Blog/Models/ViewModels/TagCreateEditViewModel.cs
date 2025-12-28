using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class TagCreateEditViewModel
    {
        public int? Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int PostCount { get; set; }
    }
}