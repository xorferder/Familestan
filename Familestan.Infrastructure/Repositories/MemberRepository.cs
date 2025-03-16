using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Member>> GetAllActiveMembersAsync()
        {
            return await _context.Members
                .Where(m => !m.IsDeleted)
                .ToListAsync();
        }
    }
}
