using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IPostWordRepository : IBaseRepository<PostWord>
    {
        Task<IEnumerable<PostWord>> GetWordsByPostIdAsync(long postId);
    }
}
