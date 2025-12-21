using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class ShareService : Service<ShareTrack>, IShareService
    {
        private readonly IShareTrackRepository _shareTrackRepository;

        public ShareService(IShareTrackRepository shareTrackRepository) : base(shareTrackRepository) => _shareTrackRepository = shareTrackRepository;

        public async Task<ICollection<ShareTrack>> GetSharesByPostIdAsync(int postId)
            => await _shareTrackRepository.GetSharesByPostIdAsync(postId);
    }
}
