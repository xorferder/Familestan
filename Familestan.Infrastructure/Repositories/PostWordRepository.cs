using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class PostWordRepository : BaseRepository<PostWord>, IPostWordRepository
    {
        public PostWordRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<PostWord>> GetWordsByPostIdAsync(long postId)
        {
            return await _context.PostWords
                .Where(pw => pw.PostWordPostId == postId)
                .ToListAsync();
        }
    }
}
