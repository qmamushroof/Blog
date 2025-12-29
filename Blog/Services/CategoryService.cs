using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository) => _categoryRepository = categoryRepository;

        public async Task<ICollection<Post>> GetPostsByCategoryId(int id)
        {
            var category = await GetByIdAsync(id);
            var posts = category!.Posts.ToList();
            return posts;
        }
    }
}
