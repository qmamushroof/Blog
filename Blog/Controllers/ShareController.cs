using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ShareController : Controller
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService) => _shareService = shareService;

        [HttpGet("share/track/{platform}/{postId}")]
        public async Task<IActionResult> TrackShare(SocialPlatform platform, int postId, [FromQuery] string url)
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

            string redirectUrl = _shareService.GetRedirectUrl(platform, url);
            return Redirect(redirectUrl);
        }
    }
}
