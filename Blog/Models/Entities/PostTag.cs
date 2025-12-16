using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class PostTag
    {
        [Key, ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post? Post { get; set; }

        [Key, ForeignKey(nameof(Tag))]
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
