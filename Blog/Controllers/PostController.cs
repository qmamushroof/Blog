using Blog.Models.Entities;
using Blog.Models.ViewModels;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IFileService _fileService;

        public PostController(IPostService postService, IFileService fileService)
        {
            _postService = postService;
            _fileService = fileService;
        }

        public async Task<IActionResult> ShowPublishedPosts()
        {
            IEnumerable<Post> posts = await _postService.GetPublishedPostsAsync();
            var postsViewModel = new List<PostListViewModel>();
            foreach (var post in posts)
            {
                var postViewModel = new PostListViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Excerpt = post.Content.Length > 300 ? post.Content.Substring(0, 300) + "..." : post.Content,
                    Author = post.AuthorId ?? "StudyNet",
                    Category = post.Category!.Name ?? "Uncategorized",
                    PublishedAt = post.PublishedAt.GetValueOrDefault(),
                    HeaderImageUrl = post.HeaderImageUrl,
                    Tags = post.PostTags.Select(pt => pt.Tag!.Name ?? "Untagged").ToList(),
                    ShareCount = post.ShareCount
                };

                postsViewModel.Add(postViewModel);
            }

            return View(postsViewModel);
        }

        [HttpPost("Upload/Image/Content")]
        public async Task<IActionResult> UploadContentImage(IFormFile file)
            => Json(new { location = await _fileService.UploadImageAsync(file) });

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }
    }
}
