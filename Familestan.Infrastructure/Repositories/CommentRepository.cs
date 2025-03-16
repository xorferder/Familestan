using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId)
        {
            return await _context.Comments
                .Where(c => c.CommentPostId == postId)
                .ToListAsync();
        }

        public async Task<int> CountCommentsForPostAsync(long postId)
        {
            return await _context.Comments
                .CountAsync(c => c.CommentPostId == postId);
        }
    }
}
