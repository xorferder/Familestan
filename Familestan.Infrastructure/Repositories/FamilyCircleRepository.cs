using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class FamilyCircleRepository : BaseRepository<FamilyCircle>, IFamilyCircleRepository
    {
        public FamilyCircleRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<FamilyCircle>> GetFamilyCircleForMemberAsync(long memberId)
        {
            return await _context.FamilyCircles
                .Where(fc => fc.FamilyCircleMemberId == memberId)
                .ToListAsync();
        }
    }
}
