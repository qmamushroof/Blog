using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post? Post { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
