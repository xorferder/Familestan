using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IFamilyTreeRepository : IBaseRepository<FamilyTree>
    {
        Task<FamilyTree?> GetTreeForRootMemberAsync(long rootMemberId);
    }
}
