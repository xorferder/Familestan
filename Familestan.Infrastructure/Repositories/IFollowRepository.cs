using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IFollowRepository : IBaseRepository<Follow>
    {
        Task<bool> IsFollowingAsync(long followerId, long followingId);
        Task<int> CountFollowersAsync(long memberId);
        Task<int> CountFollowingAsync(long memberId);
    }
}
