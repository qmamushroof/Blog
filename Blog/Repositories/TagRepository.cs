using Blog.Data;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context) : base(context) => _context = context;

        public override async Task<Tag?> GetByIdAsync(long id) => await _context.Tags
            .Include(p => p.PostTags).ThenInclude(pt => pt.Post)
            .FirstOrDefaultAsync(p => p.Id == id);

        public override async Task<Tag?> GetBySlugAsync(string slug) => await _context.Tags
            .Include(p => p.PostTags).ThenInclude(pt => pt.Post)
            .FirstOrDefaultAsync(p => p.Slug == slug);

        public override async Task<IEnumerable<Tag>> GetAllAsync() => await _context.Tags
            .Include(p => p.PostTags).ThenInclude(pt => pt.Post)
            .ToListAsync();
    }
}
