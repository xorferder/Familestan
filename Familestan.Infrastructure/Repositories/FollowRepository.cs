using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class FollowRepository : BaseRepository<Follow>, IFollowRepository
    {
        public FollowRepository(ApplicationDbContext context) : base(context) { }

        public async Task<bool> IsFollowingAsync(long followerId, long followingId)
        {
            return await _context.Follows
                .AnyAsync(f => f.FollowFollowerId == followerId && f.FollowFollowingId == followingId);
        }

        public async Task<int> CountFollowersAsync(long memberId)
        {
            return await _context.Follows
                .CountAsync(f => f.FollowFollowingId == memberId);
        }

        public async Task<int> CountFollowingAsync(long memberId)
        {
            return await _context.Follows
                .CountAsync(f => f.FollowFollowerId == memberId);
        }
    }
}
