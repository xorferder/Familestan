using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string encryptedEmail);
    }
}
