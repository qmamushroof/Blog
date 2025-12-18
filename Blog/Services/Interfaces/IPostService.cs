using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<PostListViewModel>> GetPublishedPostsAsync();
        Task<List<PostAdminListViewModel>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(int id);
        Task<Post> GetPostBySlugAsync(string slug);

        Task CreatePostAsync(PostCreateEditViewModel viewModel, string currentUserId);
        Task UpdatePostAsync(PostCreateEditViewModel viewModel, string currentUserId);
        Task DeletePostByIdAsync(int id);
    }
}
