using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IFamilyClaimRepository : IBaseRepository<FamilyClaim>
    {
        Task<IEnumerable<FamilyClaim>> GetPendingClaimsAsync();
    }
}
