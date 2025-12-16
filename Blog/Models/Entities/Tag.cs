using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
