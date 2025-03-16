using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IFamilyRelationRepository : IBaseRepository<FamilyRelation>
    {
        Task<bool> AreFamilyRelatedAsync(long member1Id, long member2Id);
        Task<IEnumerable<FamilyRelation>> GetRelationsForMemberAsync(long memberId);
    }
}
