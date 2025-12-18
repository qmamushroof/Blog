using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface IShareService
    {
        Task<List<ShareTrackViewModel>> GetSharesAsync();
        Task GetSharesByPostIdAsync(int postId);
        Task CreateShareTrackAsync(ShareTrackViewModel viewModel);
    }
}
