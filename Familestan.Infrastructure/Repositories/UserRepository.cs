using Microsoft.EntityFrameworkCore;
using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;

namespace Familestan.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string encryptedEmail)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserEncryptedEmail == encryptedEmail && !u.IsDeleted);
        }
    }
}
