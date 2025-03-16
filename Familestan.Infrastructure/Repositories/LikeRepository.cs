using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> CountLikesForPostAsync(long postId)
        {
            return await _context.Likes
                .CountAsync(l => l.LikePostId == postId);
        }

        public async Task<bool> HasUserLikedPostAsync(long memberId, long postId)
        {
            return await _context.Likes
                .AnyAsync(l => l.LikeMemberId == memberId && l.LikePostId == postId);
        }
    }
}
