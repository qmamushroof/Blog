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

        public async Task<Post?> GetBySlugAsync(string slug) => await _postRepository.GetBySlugAsync(slug);
        private ICollection<Post> OrderByPublishDate(ICollection<Post> posts) => posts.OrderByDescending(p => p.PublishedAt).ToList();

        public async Task ManageOverduePostsAsync(ICollection<Post> uncheckedPosts)
        {
            foreach (var post in uncheckedPosts)
            {
                bool statusChanged = false;
                if (post.ScheduledAt != null && post.ScheduledAt < DateTime.UtcNow && post.Status != PostStatus.Published)
                {
                    post.Status = PostStatus.Published;
                    if (post.Category != null) post.Category.PublishedPostCount++;
                    statusChanged = true;
                }
                if (post.Deadline != null && post.Deadline < DateTime.UtcNow && post.Status != PostStatus.Expired)
                {
                    post.Status = PostStatus.Expired;
                    if (post.Category != null) post.Category.PublishedPostCount--;
                    statusChanged = true;
                }

                if (statusChanged) _postRepository.Update(post);
            }
        }

        public async Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status)
        {
            var posts = await _postRepository.GetPostsByStatusAsync(status);
            await ManageOverduePostsAsync(posts);
            var orderedPosts = OrderByPublishDate(posts);
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
            var posts = await _postRepository.GetPostsByPriorityAsync(priority);
            await ManageOverduePostsAsync(posts);
            var orderedPosts = OrderByPublishDate(posts);
            return orderedPosts;
        }

        public async Task<ICollection<Post>> GetTopPostsByPriorityAsync(PostPriority priority, int count = 5)
        {
            var posts = await GetPostsByPriorityAsync(priority);
            var filteredPosts = posts.Take(count).ToList();
            return filteredPosts;
        }

        public async Task<ICollection<Post>> GetPinnedPostsAsync() => await GetTopPostsByPriorityAsync(PostPriority.Pinned);

        public async Task<ICollection<Post>> GetHotPostsAsync() => await GetTopPostsByPriorityAsync(PostPriority.Hot);

        public async Task<int> CreateAsync(Post post, ICollection<int> selectedTagIds, IFormFile? headerImageFile = null)
        {
            post.Slug = GenerateSlug(post);
            //post.AuthorId = ApplicationUser.GetUserId();
            post.CreatedAt = post.UpdatedAt = DateTime.UtcNow;

            if (post.Status == PostStatus.Published && post.Category != null) post.Category.PublishedPostCount++;

            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();

            post.HeaderImageUrl = await _fileService.UploadImageAsync(headerImageFile, post.HeaderImageUrl);

            await _postRepository.SyncTagsAsync(post, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Post updatedPost, ICollection<int> selectedTagIds, IFormFile? headerImageFile = null)
        {
            updatedPost.Slug = GenerateSlug(updatedPost);
            updatedPost.HeaderImageUrl = await _fileService.UploadImageAsync(headerImageFile, updatedPost.HeaderImageUrl);
            updatedPost.UpdatedAt = DateTime.UtcNow;

            var existingPost = await _postRepository.GetByIdAsync(updatedPost.Id);
            if (existingPost is null) return 0;

            await ManagePublishedPostCount(updatedPost, existingPost); // Recalculate the PublishedPostCount of a category using previous status+category of the post 

            _postRepository.Update(updatedPost);
            await _postRepository.SyncTagsAsync(updatedPost, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }

        private async Task ManagePublishedPostCount(Post updatedPost, Post existingPost)
        {
            if (updatedPost.Category != existingPost.Category)
            {
                if (existingPost.Status == PostStatus.Published && existingPost.Category != null) existingPost.Category.PublishedPostCount--;

                if (updatedPost.Status == PostStatus.Published && updatedPost.Category != null) updatedPost.Category.PublishedPostCount++;
            }
            else
            {
                if (updatedPost.Category is not null)
                {
                    if (existingPost.Status != PostStatus.Published && updatedPost.Status == PostStatus.Published) updatedPost.Category.PublishedPostCount++;

                    else if (existingPost.Status == PostStatus.Published && updatedPost.Status != PostStatus.Published) updatedPost.Category.PublishedPostCount--;
                }
            }
        }

        public async Task<int> SoftDeletePostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post is null) return 0;

            if (post.Status == PostStatus.Published && post.Category != null) post.Category.PublishedPostCount--;

            post.Status = PostStatus.SoftDeleted;
            post.SoftDeletedAt = DateTime.UtcNow;

            if (post.Category != null) post.Category.PublishedPostCount--;

            return await _postRepository.SaveChangesAsync();
        }

        private string GenerateSlug(Post post) => Uri.EscapeDataString($"{post.Title.ToLower().Replace(" ", "-")}-{post.Id}");

        public string GetFullUrl(Post post) => $"https://quazi-mushroof-abdullah.com/blog/{post.Slug}";
    }
}