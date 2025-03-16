using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface ILogRepository : IBaseRepository<Log>
    {
        Task<IEnumerable<Log>> GetLogsByUserIdAsync(long userId);
    }
}
