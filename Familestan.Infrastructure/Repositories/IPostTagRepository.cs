using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IPostTagRepository : IBaseRepository<PostTag>
    {
        Task<IEnumerable<PostTag>> GetTagsByPostIdAsync(long postId);
    }
}
