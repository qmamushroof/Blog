using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Services.Interfaces
{
    public interface IPostService : IService<Post>
    {
        Task<Post?> GetBySlugAsync(string slug);
        Task ManageOverduePostsAsync(ICollection<Post> posts); // Automatically publish and unpublish posts based on their scheduled and deadline times
        Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status);
        Task<Post?> GetPublishedPostByIdAsync(long id);
        Task<ICollection<Post>> GetPublishedPostsAsync();
        Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority);
        Task<ICollection<Post>> GetPinnedPostsAsync();
        Task<ICollection<Post>> GetHotPostsAsync();
        Task<ICollection<Post>> GetTopPostsByPriorityAsync(PostPriority priority, int count = 5);
        Task<int> CreateAsync(Post post, ICollection<int> selectedTagIds, IFormFile? headerImageFile);
        Task<int> UpdateAsync(Post post, ICollection<int> selectedTagIds, IFormFile? headerImageFile);
        Task<int> SoftDeletePostByIdAsync(int id);
        string GetFullUrl(Post post);
    }
}