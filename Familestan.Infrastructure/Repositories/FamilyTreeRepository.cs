using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Familestan.Infrastructure.Repositories
{
    public class FamilyTreeRepository : BaseRepository<FamilyTree>, IFamilyTreeRepository
    {
        public FamilyTreeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<FamilyTree?> GetTreeForRootMemberAsync(long rootMemberId)
        {
            return await _context.FamilyTrees
                .FirstOrDefaultAsync(ft => ft.FamilyTreeRootMemberId == rootMemberId);
        }
    }
}
