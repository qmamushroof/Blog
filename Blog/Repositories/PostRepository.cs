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

        public async Task<ICollection<Post>> GetPublishedPostsAsync()   
            => await _context.Posts.Where(p => p.Status == Status.Published).ToListAsync();
    }
}
