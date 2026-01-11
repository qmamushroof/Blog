using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status);
        Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority);
        Task SyncTagsAsync(Post post, ICollection<int>? selectedTagIds);
    }
}