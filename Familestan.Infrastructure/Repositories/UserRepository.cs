using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbSet.Update(user);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var user = await _dbSet.FindAsync(id);
            if (user != null)
            {
                _dbSet.Remove(user);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
