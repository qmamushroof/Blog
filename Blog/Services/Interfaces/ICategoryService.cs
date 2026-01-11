using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Services.Interfaces
{
    public interface ICategoryService : IService<Category>
    {
        Task<ICollection<Post>> GetPostsByCategoryIdAsync(int id);
        Task<ICollection<Post>> GetPublishedPostsByCategoryIdAsync(int id);
        string GetFullUrl(Category category);
        Task<int> CountSubmittedPostsByCategoryIdAsync(int id);
        Task<int> CountPublishedPostsByCategoryIdAsync(int id);
    }
}