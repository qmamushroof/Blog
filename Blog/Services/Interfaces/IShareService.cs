using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface IShareService : IService<ShareTrack>
    {
        Task GetSharesByPostIdAsync(int postId);
    }
}
