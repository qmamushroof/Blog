using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ShareController : ControllerBase
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService) => _shareService = shareService;
    }
}
