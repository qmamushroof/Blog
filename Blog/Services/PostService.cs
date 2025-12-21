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

        public async Task<ICollection<Post>> GetPublishedPostsAsync() => await _postRepository.GetPublishedPostsAsync();

        public async Task<int> SoftDeletePostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            post!.Status = Status.SoftDeleted;
            post.DeletedAt = DateTime.UtcNow;
            return await _postRepository.SaveChangesAsync();
        }
    }
}