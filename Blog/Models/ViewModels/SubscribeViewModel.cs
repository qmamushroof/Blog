using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class SubscribeViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
