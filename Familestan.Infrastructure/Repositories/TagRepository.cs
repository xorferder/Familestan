using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Tag?> GetByNameAsync(string tagName)
        {
            return await _context.Tags
                .FirstOrDefaultAsync(t => t.TagName == tagName);
        }
    }
}
