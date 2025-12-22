using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Services.Interfaces
{
    public interface IPostService : IService<Post>
    {
        Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status);
        Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority);
        Task<int> UpdateAsync(Post post, List<int> selectedTagIds);
        Task<int> SoftDeletePostByIdAsync(int id);
    }
}
