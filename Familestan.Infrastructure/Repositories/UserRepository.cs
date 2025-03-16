using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string encryptedEmail)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserEncryptedEmail == encryptedEmail);
        }
    }
}
