using Blog.Data;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories
{
    public class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
    {
        private readonly ApplicationDbContext _context;
        public SubscriberRepository(ApplicationDbContext context) : base(context) => _context = context;
    }
}
