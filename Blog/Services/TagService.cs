using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Repositories;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class TagService : Service<Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IPostService _postService;

        public TagService(ITagRepository tagRepository, IPostService postService) : base(tagRepository)
        {
            _tagRepository = tagRepository;
            _postService = postService;
        }

        public async Task<Tag?> GetBySlugAsync(string slug) => await _tagRepository.GetBySlugAsync(slug);

        public async Task<ICollection<Post>> GetPostsByTagIdAsync(int id)
        {
            var tag = await GetByIdAsync(id);
            var postIds = tag!.PostTags.Select(pt => pt.PostId).ToList();

            var posts = new List<Post>();

            foreach (int postId in postIds)
            {
                var post = await _postService.GetByIdAsync(postId);
                posts.Add(post);
            }

            await _postService.ManageOverduePostsAsync(posts);
            return posts;
        }

        public async Task<ICollection<Post>> GetPublishedPostsByTagIdAsync(int id)
        {
            var posts = await GetPostsByTagIdAsync(id);
            var publishedPosts = posts.Where(p => p.Status == PostStatus.Published).ToList();
            return publishedPosts;
        }

        public override async Task<int> CreateAsync(Tag tag)
        {
            tag.Slug = GenerateSlug(tag);
            await _tagRepository.AddAsync(tag);
            return await _tagRepository.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(Tag tag)
        {
            tag.Slug = GenerateSlug(tag);
            _tagRepository.Update(tag);
            return await _tagRepository.SaveChangesAsync();
        }

        private string GenerateSlug(Tag tag) => Uri.EscapeDataString($"{tag.Name.ToLower().Replace(" ", "-")}-{tag.Id}");

        public string GetFullUrl(Tag tag) => $"https://quazi-mushroof-abdullah.com/blog/{tag.Slug}";

        public async Task<int> CountSubmittedPostsByTagIdAsync(int id)
        {
            var posts = await GetPostsByTagIdAsync(id);
            return posts.Count;
        }

        public async Task<int> CountPublishedPostsByTagIdAsync(int id)
        {
            var posts = await GetPublishedPostsByTagIdAsync(id);
            return posts.Count;
        }
    }
}
