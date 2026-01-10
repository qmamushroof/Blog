using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostService _postService;

        public CategoryService(ICategoryRepository categoryRepository, IPostService postService) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _postService = postService;
        }

        public async Task<ICollection<Post>> GetPostsByCategoryIdAsync(int id)
        {
            var category = await GetByIdAsync(id);
            var uncheckedPosts = category!.Posts.ToList();

            var checkedPosts = await _postService.ExpireOverduePostsAsync(uncheckedPosts);
            return checkedPosts;
        }

        public override async Task<int> CreateAsync(Category category)
        {
            category.Slug = GenerateSlug(category);
            await _categoryRepository.AddAsync(category);
            return await _categoryRepository.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(Category category)
        {
            category.Slug = GenerateSlug(category);
            _categoryRepository.Update(category);
            return await _categoryRepository.SaveChangesAsync();
        }

        private string GenerateSlug(Category category) => Uri.EscapeDataString($"{category.Name.ToLower().Replace(" ", "-")}-{category.Id}");

        public string GetFullUrl(Category category) => $"https://quazi-mushroof-abdullah.com/blog/{category.Slug}";
    }
}
