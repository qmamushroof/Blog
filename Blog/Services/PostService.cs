using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class PostService : Service<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository) : base(postRepository) => _postRepository = postRepository;
        public async Task<List<Post>> GetPublishedPostsAsync()
        {
            await _postRepository.GetPublishedPostsAsync();
            throw new NotImplementedException();
        }


        public Task SoftDeletePostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}