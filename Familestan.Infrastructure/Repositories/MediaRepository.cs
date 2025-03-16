using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        public MediaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Media>> GetMediaByPostIdAsync(long postId)
        {
            return await _context.Media
                .Where(m => m.MediaPostId == postId)
                .ToListAsync();
        }
    }
}
