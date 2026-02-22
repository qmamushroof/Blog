using Blog.Data;
using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context) : base(context) => _context = context;

        public override async Task<Post?> GetByIdAsync(long id) => await _context.Posts
            .Include(p => p.Category)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Post?> GetBySlugAsync(string slug) => await _context.Posts
            .Include(p => p.Category)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .FirstOrDefaultAsync(p => p.Slug == slug);

        public override async Task<IEnumerable<Post>> GetAllAsync() => await _context.Posts
            .Include(p => p.Category)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .ToListAsync();

        public async Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status)
            => await _context.Posts.Where(p => p.Status == status)
            .Include(p => p.Category)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .ToListAsync();

        public async Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority)
            => await _context.Posts.Where(p => p.Priority == priority)
            .Include(p => p.Category)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .ToListAsync();

        public async Task SyncTagsAsync(Post post, ICollection<int>? selectedTagIds)
        {
            var existingPostTagsOfThisPost =
                await _context.PostTags.Where(pt => pt.PostId == post.Id).ToListAsync();

            var postTagsToBeRemovedFromThisPost =
                selectedTagIds == null ? existingPostTagsOfThisPost :
                existingPostTagsOfThisPost.Where(pt => !selectedTagIds.Contains(pt.TagId)).ToList();

            _context.PostTags.RemoveRange(postTagsToBeRemovedFromThisPost);

            var tagIdsToBeAddedToThisPost =
                selectedTagIds == null ? new List<int>() :
                selectedTagIds.Where(tagId => !existingPostTagsOfThisPost.Any(pt => pt.TagId == tagId)).ToList();

            var postTagsToBeAddedToThisPost =
                tagIdsToBeAddedToThisPost.Select(tagId => new PostTag { PostId = post.Id, TagId = tagId }).ToList();

            await _context.PostTags.AddRangeAsync(postTagsToBeAddedToThisPost);
        }
    }
}