using Blog.Models.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface IShareTrackRepository : IRepository<ShareTrack>
    {
        Task<ShareTrack> GetSharesByPostIdAsync(int postId);
    }
}
