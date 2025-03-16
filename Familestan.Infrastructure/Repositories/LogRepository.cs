using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Log>> GetLogsByUserIdAsync(long userId)
        {
            return await _context.Logs
                .Where(l => l.LogUserId == userId)
                .ToListAsync();
        }
    }
}
