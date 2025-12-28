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

        public async Task<ICollection<Post>> GetPostsByStatusAsync(PostStatus status)
            => await _context.Posts.Where(p => p.Status == status).ToListAsync();

        public async Task<ICollection<Post>> GetPostsByPriorityAsync(PostPriority priority)
            => await _context.Posts.Where(p => p.Priority == priority).ToListAsync();

        public async Task UpdateAsync(Post post, List<int> selectedTagIds)
        {
            var existingPostTagsOfThisPost =
                await _context.PostTags.Where(pt => pt.PostId == post.Id).ToListAsync();

            var postTagsToBeRemovedFromThisPost =
                existingPostTagsOfThisPost.Where(pt => !selectedTagIds.Contains(pt.TagId)).ToList();

            _context.PostTags.RemoveRange(postTagsToBeRemovedFromThisPost);

            var tagIdsToBeAddedToThisPost =
                selectedTagIds.Where(tagId => !existingPostTagsOfThisPost.Any(pt => pt.TagId == tagId)).ToList();

            var postTagsToBeAddedToThisPost =
                tagIdsToBeAddedToThisPost.Select(tagId => new PostTag { PostId = post.Id, TagId = tagId }).ToList();

            await _context.PostTags.AddRangeAsync(postTagsToBeAddedToThisPost);
        }
    }
}