using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;
using System.Threading.Tasks;

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
            var uncheckedPosts = (await _postService.GetAllAsync())
                .Where(p => p.CategoryId == id)
                .ToList();

            var checkedPosts = await _postService.ManageOverduePostsAsync(uncheckedPosts);
            return checkedPosts;
        }

        public async Task<ICollection<Post>> GetPublishedPostsByCategoryIdAsync(int id)
        {
            var posts = await GetPostsByCategoryIdAsync(id);
            var publishedPosts = posts.Where(p => p.Status == PostStatus.Published).ToList();
            return publishedPosts;
        }

        private string GenerateSlug(Category category) => Uri.EscapeDataString($"{category.Name.ToLower().Replace(" ", "-")}-{category.Id}");

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

        public string GetFullUrl(Category category) => $"https://quazi-mushroof-abdullah.com/blog/{category.Slug}";

        public async Task<int> CountSubmittedPostsByCategoryIdAsync(int id)
        {
            var categories = await GetPostsByCategoryIdAsync(id);
            return categories.Count;
        }

        public async Task<int> CountPublishedPostsByCategoryIdAsync(int id)
        {
            var categories = await GetPublishedPostsByCategoryIdAsync(id);
            return categories.Count;
        }
    }
}
