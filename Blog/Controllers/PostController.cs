using Blog.Models.Entities;
using Blog.Models.ViewModels;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IFileService _fileService;

        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService, IFileService fileService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _fileService = fileService;
        }

        public async Task<IActionResult> AllPosts()
        {
            IEnumerable<Post> posts = await _postService.GetAllAsync();
            var postsViewModel = new List<PostAdminListViewModel>();
            foreach (var post in posts)
            {
                var viewModel = new PostAdminListViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Excerpt = post.Content.Length > 300 ? post.Content.Substring(0, 300) + "..." : post.Content,
                    HeaderImageUrl = post.HeaderImageUrl,
                    Author = post.AuthorId ?? "Quazi Mushroof Abdullah",
                    Category = post.Category!.Name ?? "Uncategorized",
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt,
                    ScheduledAt = post.ScheduledAt.GetValueOrDefault(),
                    PublishedAt = post.PublishedAt.GetValueOrDefault(),
                    Deadline = post.Deadline.GetValueOrDefault(),
                    SoftDeletedAt = post.SoftDeletedAt.GetValueOrDefault(),
                    Tags = post.PostTags.Select(pt => pt.Tag!.Name ?? "Untagged").ToList(),
                    ShareCount = post.ShareCount
                };

                postsViewModel.Add(viewModel);
            }
            return View(postsViewModel);
        }

        public async Task<IActionResult> PublishedPosts()
        {
            IEnumerable<Post> posts = await _postService.GetPublishedPostsAsync();
            var postsViewModel = new List<PostListViewModel>();
            foreach (var post in posts)
            {
                var viewModel = new PostListViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Excerpt = post.Content.Length > 300 ? post.Content.Substring(0, 300) + "..." : post.Content,
                    Author = post.AuthorId ?? "Quazi Mushroof Abdullah",
                    Category = post.Category!.Name ?? "Uncategorized",
                    PublishedAt = post.PublishedAt.GetValueOrDefault(),
                    HeaderImageUrl = post.HeaderImageUrl,
                    Tags = post.PostTags.Select(pt => pt.Tag!.Name ?? "Untagged").ToList(),
                    ShareCount = post.ShareCount
                };

                postsViewModel.Add(viewModel);
            }
            return View(postsViewModel);
        }

        public async Task<IActionResult> PostDetail(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            var viewModel = new PostDetailViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                HeaderImageUrl = post.HeaderImageUrl,
                Author = post.AuthorId,
                Category = post.Category.ToString(),
                PublishedAt = post.PublishedAt,
                Tags = post.PostTags.Select(pt => pt.Tag.Name ?? "Untagged").ToList(),
                ShareCount = post.ShareCount
            };
            return View(viewModel);
        }

        public async Task<IActionResult> PostCreate()
        {
            var viewModel = new PostCreateEditViewModel
            {
                Categories = (await _categoryService.GetAllAsync())
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .ToList(),

                Tags = (await _tagService.GetAllAsync())
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name })
                .OrderBy(t => t.Text)
                .ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(PostCreateEditViewModel viewModel)
        {
            var post = new Post
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                Status = viewModel.Status,
                Priority = viewModel.Priority,
                ScheduledAt = viewModel.ScheduledAt,
                Deadline = viewModel.Deadline,
                CategoryId = viewModel.CategoryId
            };
            await _postService.CreateAsync(post, viewModel.SelectedTagIds, viewModel.HeaderImageFile);
            return View();
        }

        public async Task<IActionResult> PostEdit(int id)
        {
            var post = await _postService.GetByIdAsync(id);

            var viewModel = new PostCreateEditViewModel
            {
                Id = id,
                Title = post.Title,
                Content = post.Content,
                HeaderImageUrl = post.HeaderImageUrl,
                Status = post.Status,
                Priority = post.Priority,
                ScheduledAt = post.ScheduledAt,
                Deadline = post.Deadline,
                CategoryId = post.CategoryId,

                Categories = (await _categoryService.GetAllAsync())
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .ToList(),

                SelectedTagIds = post.PostTags.Select(pt => pt.TagId).ToList(),

                Tags = (await _tagService.GetAllAsync())
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name })
                .OrderBy(t => t.Text)
                .ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostEdit(PostCreateEditViewModel viewModel)
        {
            var post = new Post
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                Status = viewModel.Status,
                Priority = viewModel.Priority,
                ScheduledAt = viewModel.ScheduledAt,
                Deadline = viewModel.Deadline,
                CategoryId = viewModel.CategoryId
            };
            await _postService.UpdateAsync(post, viewModel.SelectedTagIds, viewModel.HeaderImageFile);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostDelete(int id)
        {
            var post = _postService.SoftDeletePostByIdAsync(id);
            return View();
        }

        [HttpPost("Upload/Image/Content")]
        public async Task<IActionResult> UploadContentImage(IFormFile file)
            => Json(new { location = await _fileService.UploadImageAsync(file) });
    }
}
