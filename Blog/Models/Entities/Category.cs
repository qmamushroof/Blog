using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }

        public ICollection<Post>? Posts { get; set; } = new List<Post>();
    }
}
