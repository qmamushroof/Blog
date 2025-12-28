using Blog.Models.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface IShareTrackRepository : IRepository<ShareTrack>
    {
        Task<ICollection<ShareTrack>> GetSharesByPostIdAsync(int postId);
    }
}