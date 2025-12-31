using Blog.Models.Entities;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ShareController : ControllerBase
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService) => _shareService = shareService;

        [HttpGet("share/track/{platform}/{postId}")]
        public async Task<IActionResult> TrackShare(string platform, int postId, [FromQuery] string url)
        {
            var share = new ShareTrack
            {
                Platform = platform,
                ShareUrl = url,
                SharedAt = DateTime.UtcNow,
                UserIp = HttpContext.Connection.RemoteIpAddress,
                PostId = postId
            };
            await _shareService.TrackShareAsync(share);

            string redirectUrl = platform.ToLower() switch
            {
                "facebook" => $"https://www.facebook.com/sharer.php?u={Uri.EscapeDataString(url)}",
                "twitter" => $"https://twitter.com/intent/tweet?url={Uri.EscapeDataString(url)}",
                "linkedin" => $"https://www.linkedin.com/sharing/share-offsite/?url={Uri.EscapeDataString(url)}",
                "whatsapp" => $"https://api.whatsapp.com/send?url={Uri.EscapeDataString(url)}",
                "reddit" => $"https://reddit.com/submit?url={Uri.EscapeDataString(url)}",
                "telegram" => $"https://t.me/share/url?url={Uri.EscapeDataString(url)}",
                _ => url
            };

            return Redirect(redirectUrl);
        }
    }
}
