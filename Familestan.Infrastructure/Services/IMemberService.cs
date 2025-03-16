using Familestan.Core.Models;

namespace Familestan.Infrastructure.Services
{
    public interface IMemberService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        
        Task<string> GenerateOtpAsync(string target, string type, long? memberId); // ⬅️ اضافه شد
        Task<bool> VerifyOtpAsync(string target, string otpCode); // ⬅️ اضافه شد
    }
}
