using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Familestan.Infrastructure.Repositories
{
    public class OtpVerificationRepository : BaseRepository<OtpVerification>, IOtpVerificationRepository
    {
        public OtpVerificationRepository(ApplicationDbContext context) : base(context) { }
        public async Task<OtpVerification?> GetLatestOtpAsync(string target)
        {
            return await _context.OtpVerifications
                .Where(o => o.OtpTarget == target && !o.OtpIsUsed)
                .OrderByDescending(o => o.OtpExpiration)
                .FirstOrDefaultAsync();
        }
    }

}

