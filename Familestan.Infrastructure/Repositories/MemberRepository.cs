using Microsoft.EntityFrameworkCore;
using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;

namespace Familestan.Infrastructure.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Member>> GetFamilyMembersAsync(long userId)
        {
            return await _dbSet.Where(m => m.MemberUserId == userId && (m.IsDeleted == false)).ToListAsync();
        }

    }
}
