using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class CategoryCreateEditViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}