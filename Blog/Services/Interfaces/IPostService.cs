using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface IPostService : IService<Post>
    {        
        Task<List<Post>> GetPublishedPostsAsync();
        Task SoftDeletePostByIdAsync(int id);
    }
}
