using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class FamilyRelationRepository : BaseRepository<FamilyRelation>, IFamilyRelationRepository
    {
        public FamilyRelationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<bool> AreFamilyRelatedAsync(long member1Id, long member2Id)
        {
            return await _context.FamilyRelations
                .AnyAsync(fr => (fr.FamilyRelationMember1Id == member1Id && fr.FamilyRelationMember2Id == member2Id) ||
                                (fr.FamilyRelationMember1Id == member2Id && fr.FamilyRelationMember2Id == member1Id));
        }

        public async Task<IEnumerable<FamilyRelation>> GetRelationsForMemberAsync(long memberId)
        {
            return await _context.FamilyRelations
                .Where(fr => fr.FamilyRelationMember1Id == memberId || fr.FamilyRelationMember2Id == memberId)
                .ToListAsync();
        }
    }
}
