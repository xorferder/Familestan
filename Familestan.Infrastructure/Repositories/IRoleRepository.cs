using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role?> GetByNameAsync(string roleName);
    }
}
