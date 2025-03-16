using Microsoft.EntityFrameworkCore;
using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;

namespace Familestan.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Post>> GetPostsByMemberIdAsync(long memberId)
        {
            return await _dbSet.Where(p => p.PostMemberId == memberId && (p.IsDeleted == false)).ToListAsync();
        }

    }
}
