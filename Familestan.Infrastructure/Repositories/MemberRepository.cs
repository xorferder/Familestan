using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Member?> GetByUserIdAsync(long userId)
        {
            return await _context.Set<Member>()
                .FirstOrDefaultAsync(m => m.UserId == userId && !m.IsDeleted);
        }
    }
}
