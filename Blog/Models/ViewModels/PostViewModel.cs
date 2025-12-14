using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        [Required]
        [StringLength(300)]
        public string? Title { get; set; }
    }
}