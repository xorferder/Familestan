using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        Task<int> CountLikesForPostAsync(long postId);
        Task<bool> HasUserLikedPostAsync(long memberId, long postId);
    }
}
