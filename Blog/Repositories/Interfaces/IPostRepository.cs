using Blog.Models.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<ICollection<Post>> GetPublishedPostsAsync();
    }
}
