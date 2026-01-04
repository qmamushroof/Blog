using Blog.Data;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context) : base(context) => _context = context;
    }
}
