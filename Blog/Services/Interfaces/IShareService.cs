using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface IShareService : IService<ShareTrack>
    {
        Task<ICollection<ShareTrack>> GetSharesByPostIdAsync(int postId);
        Task<int> TrackShareAsync(ShareTrack share);
        string GetRedirectUrl(string platform, string url);
    }
}