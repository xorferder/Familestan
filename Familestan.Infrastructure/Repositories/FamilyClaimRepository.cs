using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class FamilyClaimRepository : BaseRepository<FamilyClaim>, IFamilyClaimRepository
    {
        public FamilyClaimRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<FamilyClaim>> GetPendingClaimsAsync()
        {
            return await _context.FamilyClaims
                .Where(fc => !fc.FamilyClaimIsVerified)
                .ToListAsync();
        }
    }
}
