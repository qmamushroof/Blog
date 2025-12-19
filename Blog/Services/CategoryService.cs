using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository) => _categoryRepository = categoryRepository;

        public Task<int> CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
