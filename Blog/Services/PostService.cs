using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class PostService : Service<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IFileService _fileService;

        public PostService(IPostRepository postRepository, IFileService fileService) : base(postRepository)
        {
            _postRepository = postRepository;
            _fileService = fileService;
        }

        private ICollection<Post> OrderByPublishDate(ICollection<Post> posts) => posts.OrderByDescending(p => p.PublishedAt).ToList();

        public async Task<ICollection<Post>> ManageOverduePostsAsync(ICollection<Post> uncheckedPosts)
        {
            var checkedPosts = new List<Post>();
            foreach (var post in uncheckedPosts)
            {
                if (post.ScheduledAt != null && post.ScheduledAt < DateTime.UtcNow && post.Status != PostStatus.Published)
                {
                    post.Status = PostStatus.Published;
                    post.Category.PublishedPostCount++;
                }
                if (post.Deadline != null && post.Deadline < DateTime.UtcNow && post.Status != PostStatus.Expired)
                {
                    post.Status = PostStatus.Expired;
                    post.Category.PublishedPostCount--;
                }
                await UpdateAsync(post);
                checkedPosts.Add(post);
            }
            return checkedPosts;
        }

        public async Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status)
        {
            var uncheckedPosts = await _postRepository.GetPostsByStatusAsync(status);
            var checkedPosts = await ManageOverduePostsAsync(uncheckedPosts);
            var orderedPosts = OrderByPublishDate(checkedPosts);
            return orderedPosts;
        }

        public async Task<Post?> GetPublishedPostByIdAsync(long id)
        {
            var posts = await GetPublishedPostsAsync();
            var post = posts.FirstOrDefault(p => p.Id == id);
            return post;
        }

        public async Task<ICollection<Post>> GetPublishedPostsAsync()
            => await GetPostsByStatusAsync(PostStatus.Published);

        public async Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority)
        {
            var uncheckedPosts = await _postRepository.GetPostsByPriorityAsync(priority);
            var checkedPosts = await ManageOverduePostsAsync(uncheckedPosts);
            var orderedPosts = OrderByPublishDate(checkedPosts);
            return orderedPosts;
        }

        public async Task<ICollection<Post>> GetTopPostsByPriorityAsync(PostPriority priority, int count = 5)
        {
            var posts = await GetPostsByPriorityAsync(priority);
            var filteredPosts = posts.Take(count).ToList();
            return filteredPosts;
        }

        public async Task<ICollection<Post>> GetPinnedPostsAsync()
            => await GetTopPostsByPriorityAsync(PostPriority.Pinned);

        public async Task<ICollection<Post>> GetHotPostsAsync()
            => await GetTopPostsByPriorityAsync(PostPriority.Hot);

        public async Task<int> CreateAsync(Post post, ICollection<int> selectedTagIds, IFormFile? headerImageFile = null)
        {
            post.Slug = GenerateSlug(post);
            //post.AuthorId = ApplicationUser.GetUserId();
            post.CreatedAt = DateTime.UtcNow;
            post.UpdatedAt = DateTime.UtcNow;

            if (post.Status == PostStatus.Published && post.Category != null) post.Category.PublishedPostCount++;

            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();

            post.HeaderImageUrl = await _fileService.UploadImageAsync(headerImageFile, post.HeaderImageUrl);

            await _postRepository.SyncTagsAsync(post, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Post post, ICollection<int> selectedTagIds, IFormFile? headerImageFile = null)
        {
            post.Slug = GenerateSlug(post);

            post.HeaderImageUrl = await _fileService.UploadImageAsync(headerImageFile!, post.HeaderImageUrl);

            post.UpdatedAt = DateTime.UtcNow;

            // Update logic needs to use previous status and category of the post to calculate the PublishedPostCount under category

            //if (post.Category != null)
            //{
            //    if (post.Status == PostStatus.Published) post.Category.PublishedPostCount++; ;
            //}

            _postRepository.Update(post);
            await _postRepository.SyncTagsAsync(post, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }

        public async Task<int> SoftDeletePostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            post!.Status = PostStatus.SoftDeleted;
            post.SoftDeletedAt = DateTime.UtcNow;

            if (post.Category != null) post.Category.PublishedPostCount--;

            return await _postRepository.SaveChangesAsync();
        }

        private string GenerateSlug(Post post) => Uri.EscapeDataString($"{post.Title.ToLower().Replace(" ", "-")}-{post.Id}");

        public string GetFullUrl(Post post) => $"https://quazi-mushroof-abdullah.com/blog/{post.Slug}";
    }
}