using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Services.Interfaces
{
    public interface IPostService : IService<Post>
    {
        Task<ICollection<Post>> ExpireOverduePostsAsync(ICollection<Post> posts);
        Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status);
        Task<ICollection<Post>> GetPublishedPostsAsync();
        Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority);
        Task<ICollection<Post>> GetPinnedPostsAsync();
        Task<ICollection<Post>> GetHotPostsAsync();
        Task<ICollection<Post>> GetTopPostsByPriorityAsync(PostPriority priority, int count = 5);
        Task<int> CreateAsync(Post post, List<int> selectedTagIds, IFormFile? headerImageFile);
        Task<int> UpdateAsync(Post post, List<int> selectedTagIds, IFormFile? headerImageFile);
        Task<int> SoftDeletePostByIdAsync(int id);
        string GenerateSlug(Post post) => Uri.EscapeDataString($"{post.Title}-{post.Id}");
        string GetFullUrl(Post post);
    }
}