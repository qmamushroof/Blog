using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class PostEntity : BaseEntity
    {
        [Required]
        [StringLength(300)]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public string? Author { get; set; }

        [ForeignKey(nameof(Comment))]
        public List<CommentEntity>? Comments { get; set; }
        [ValidateNever]
        public CommentEntity? Comment { get; set; }
    }
}
