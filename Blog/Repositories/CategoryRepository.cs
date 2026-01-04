using Blog.Data;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) => _context = context;
    }
}
