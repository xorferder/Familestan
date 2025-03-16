using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId);
        Task<int> CountCommentsForPostAsync(long postId);
    }
}
