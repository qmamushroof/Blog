using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class Comment : Base
    {
        public string? Content { get; set; }
        public string? Author { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        [ValidateNever]
        public Post? Post { get; set; }
    }
}
