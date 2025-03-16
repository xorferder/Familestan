using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface IOtpVerificationRepository : IBaseRepository<OtpVerification>
    {
        Task<OtpVerification?> GetLatestOtpAsync(string target);
    }
}
