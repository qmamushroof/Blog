using Blog.Data;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) => _context = context;
        public async Task<Category?> GetBySlugAsync(string slug) => await _context.Categories
            .FirstOrDefaultAsync(p => p.Slug == slug);
    }
}
