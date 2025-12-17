using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class SubscribeViewModel
    {
        [Required, EmailAddress,StringLength(200)]
        public string Email { get; set; } = string.Empty;
    }
}
