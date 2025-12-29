using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class TagService : Service<Tag>, ITagService
    {
        private readonly IPostRepository _postRepository;
        public TagService(ITagRepository tagRepository, IPostRepository postRepository) : base(tagRepository) => _postRepository = postRepository;

        public async Task<ICollection<Post>> GetPostsByTagIdAsync(int id)
        {
            var tag = await GetByIdAsync(id);
            var postIds = tag!.PostTags.Select(pt => pt.PostId).ToList();

            var posts = new List<Post>();
            foreach (int postId in postIds)
            {
                var post = await _postRepository.GetByIdAsync(postId);
                posts.Add(post!);
            }
            return posts;
        }
    }
}
