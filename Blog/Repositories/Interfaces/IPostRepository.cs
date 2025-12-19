using Blog.Models.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPublishedPostsAsync();
        Task<Post> GetPostBySlugAsync(string slug);
        Task SoftDeletePostByIdAsync(int id);
    }
}
