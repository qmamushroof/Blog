using Blog.Models.Entities;

namespace Blog.Models.ViewModels
{
    public class CategoryListDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public int? PostCount { get; set; }
    }
}