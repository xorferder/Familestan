using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class PostTagRepository : BaseRepository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<PostTag>> GetTagsByPostIdAsync(long postId)
        {
            return await _context.PostTags
                .Where(pt => pt.PostTagPostId == postId)
                .ToListAsync();
        }
    }
}
