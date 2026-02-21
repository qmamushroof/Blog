using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Slug { get; set; } = string.Empty;
        
        public int? PublishedPostCount { get; set; }
        
        public int? DisplayOrder { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}