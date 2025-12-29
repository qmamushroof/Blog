using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository) { }

        public async Task<ICollection<Post>> GetPostsByCategoryIdAsync(int id)
        {
            var category = await GetByIdAsync(id);
            var posts = category!.Posts.ToList();
            return posts;
        }
    }
}
