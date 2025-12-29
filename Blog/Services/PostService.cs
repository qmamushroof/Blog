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

        public async Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status)
        {
            var posts = await _postRepository.GetPostsByStatusAsync(status);
            var orderedPosts = OrderByPublishDate(posts);
            return orderedPosts;
        }

        public async Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority)
        {
            var posts = await _postRepository.GetPostsByPriorityAsync(priority);
            var orderedPosts = OrderByPublishDate(posts);
            return orderedPosts;
        }

        public async Task<ICollection<Post>> GetTopPostsByPriorityAsync(PostPriority priority, int count = 5)
        {
            var posts = await GetPostsByPriorityAsync(priority);
            var filteredPosts = posts.Take(count).ToList();
            return filteredPosts;
        }

        public async Task<int> CreateAsync(Post post, List<int> selectedTagIds, IFormFile? headerImageFile = null)
        {
            post.HeaderImageUrl = await _fileService.UploadHeaderImageAsync(headerImageFile!, post, post.HeaderImageUrl);

            post.CreatedAt = DateTime.UtcNow;
            post.UpdatedAt = DateTime.UtcNow;

            await _postRepository.AddAsync(post);
            await _postRepository.SyncTagsAsync(post.Id, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Post post, List<int> selectedTagIds, IFormFile? headerImageFile = null)
        {
            post.HeaderImageUrl = await _fileService.UploadHeaderImageAsync(headerImageFile!, post, post.HeaderImageUrl);

            post.UpdatedAt = DateTime.UtcNow;

            _postRepository.Update(post);
            await _postRepository.SyncTagsAsync(post.Id, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }

        public async Task<int> SoftDeletePostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            post!.Status = PostStatus.SoftDeleted;
            post.DeletedAt = DateTime.UtcNow;
            return await _postRepository.SaveChangesAsync();
        }
    }
}