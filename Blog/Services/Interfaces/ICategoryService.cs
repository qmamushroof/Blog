using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category?> GetBySlugAsync(string slug);
        Task<ICollection<Post>> GetPostsByCategoryIdAsync(int id);
        Task<ICollection<Post>> GetPublishedPostsByCategoryIdAsync(int id);
        string GetFullUrl(Category category);
        Task<int> CountSubmittedPostsByCategoryIdAsync(int id);
    }
}