using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class PostService : Service<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository) : base(postRepository) => _postRepository = postRepository;

        public async Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status) => await _postRepository.GetPostsByStatusAsync(status);

        public async Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority) => await _postRepository.GetPostsByPriorityAsync(priority);

        public async Task<int> SoftDeletePostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            post!.Status = PostStatus.SoftDeleted;
            post.DeletedAt = DateTime.UtcNow;
            return await _postRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Post post, List<int> selectedTagIds)
        {
            await _postRepository.UpdateAsync(post, selectedTagIds);
            return await _postRepository.SaveChangesAsync();
        }
    }
}