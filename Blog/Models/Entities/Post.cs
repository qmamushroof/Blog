using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class Post : Base
    {
        public string? Title { get; set; }

        [ValidateNever]
        public List<Comment>? Comments { get; set; }
    }
}
