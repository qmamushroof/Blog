using Blog.Data;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class ShareTrackRepository : Repository<ShareTrack>, IShareTrackRepository
    {
        private readonly ApplicationDbContext _context;

        public ShareTrackRepository(ApplicationDbContext context) : base(context) => _context = context;

        public async Task<ICollection<ShareTrack>> GetSharesByPostIdAsync(int postId)
            => await _context.ShareTracks.Where(st => st.PostId == postId).ToListAsync();
    }
}