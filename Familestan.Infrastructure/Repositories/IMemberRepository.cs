using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<Member?> GetByUserIdAsync(long userId);
    }
}
