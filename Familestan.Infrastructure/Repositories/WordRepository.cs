using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class WordRepository : BaseRepository<Word>, IWordRepository
    {
        public WordRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Word?> GetByTextAsync(string wordText)
        {
            return await _context.Words
                .FirstOrDefaultAsync(w => w.WordText == wordText);
        }
    }
}
