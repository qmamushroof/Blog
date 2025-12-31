using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface IShareService : IService<ShareTrack>
    {
        Task<ICollection<ShareTrack>> GetSharesByPostIdAsync(int postId);
        Task<int> TrackShareAsync(ShareTrack share);
    }
}