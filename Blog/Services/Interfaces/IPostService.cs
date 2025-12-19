using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface IPostService : IService<Post>
    {        
        Task<List<PostListViewModel>> GetPublishedPostsAsync();
        Task<List<PostAdminListViewModel>> GetPostsAsync();

        Task CreatePostAsync(PostCreateEditViewModel viewModel);
        Task UpdatePostAsync(PostCreateEditViewModel viewModel);
        Task SoftDeletePostByIdAsync(int id);
    }
}
