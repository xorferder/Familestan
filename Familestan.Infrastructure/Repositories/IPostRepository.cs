using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByMemberIdAsync(long memberId);
    }
}
