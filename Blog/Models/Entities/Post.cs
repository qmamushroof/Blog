using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Post : Base
    {
        [Required]
        [StringLength(300)]
        public string? Title { get; set; }

        [ValidateNever]
        public List<Comment>? Comments { get; set; }
    }
}
