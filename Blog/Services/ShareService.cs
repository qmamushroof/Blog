using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class ShareService : Service<ShareTrack>, IShareService
    {
        private readonly IShareTrackRepository _shareTrackRepository;
        private readonly IPostService _postService;

        public ShareService(IShareTrackRepository shareTrackRepository, IPostService postService) : base(shareTrackRepository)
        {
            _shareTrackRepository = shareTrackRepository;
            _postService = postService;
        }

        private async Task<int> IncrementShareCountAsync(int postId)
        {
            var post = await _postService.GetByIdAsync(postId);
            post!.ShareCount++;
            return await _postService.UpdateAsync(post);
        }

        public async Task<ICollection<ShareTrack>> GetSharesByPostIdAsync(int postId)
            => await _shareTrackRepository.GetSharesByPostIdAsync(postId);

        public async Task<int> TrackShareAsync(ShareTrack share)
        {
            await IncrementShareCountAsync(share.PostId);
            return await CreateAsync(share);
        }

        public string GetRedirectUrl(string platform, string url)
            => platform.ToLower() switch
            {
                "facebook" => $"https://www.facebook.com/sharer.php?u={Uri.EscapeDataString(url)}",
                "twitter" => $"https://twitter.com/intent/tweet?url={Uri.EscapeDataString(url)}",
                "linkedin" => $"https://www.linkedin.com/sharing/share-offsite/?url={Uri.EscapeDataString(url)}",
                "whatsapp" => $"https://api.whatsapp.com/send?url={Uri.EscapeDataString(url)}",
                "reddit" => $"https://reddit.com/submit?url={Uri.EscapeDataString(url)}",
                "telegram" => $"https://t.me/share/url?url={Uri.EscapeDataString(url)}",
                _ => url
            };
    }
}