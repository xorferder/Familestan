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
            return await _context.OtpVerifications // ✅ مستقیماً از `_context` ارث‌بری شده استفاده کن
                .Where(o => o.OtpTarget == target && !o.OtpIsUsed)
                .OrderByDescending(o => o.OtpExpiration)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> VerifyOtpAsync(string target, string otpCode)
        {
            var otp = await _context.OtpVerifications
                .Where(o => o.OtpTarget == target && o.OtpCode == otpCode && !o.OtpIsUsed && o.OtpExpiration > DateTime.UtcNow)
                .FirstOrDefaultAsync();

            if (otp == null) return false;

            otp.OtpIsUsed = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
