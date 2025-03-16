using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IFamilyCircleRepository : IBaseRepository<FamilyCircle>
    {
        Task<IEnumerable<FamilyCircle>> GetFamilyCircleForMemberAsync(long memberId);
    }
}
