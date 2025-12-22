using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Services.Interfaces
{
    public interface IPostService : IService<Post>
    {
        Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status);
        Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority);
        Task<ICollection<Post>> GetTopPostsByPriorityAsync(PostPriority priority, int count = 5);
        Task<int> UpdateAsync(Post post, List<int> selectedTagIds);
        Task<int> SoftDeletePostByIdAsync(int id);
    }
}
