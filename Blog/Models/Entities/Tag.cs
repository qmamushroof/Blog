using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Slug { get; set; }

        public ICollection<PostTag>? PostTags { get; set; } = new List<PostTag>();
    }
}
