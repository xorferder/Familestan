using Familestan.Core.Models;

namespace Familestan.Infrastructure.Services
{
    public interface IMemberService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<bool> VerifyOtpAsync(VerifyOtpDto dto);
        Task<string?> LoginAsync(LoginDto dto); // ⬅️ اضافه کردن متد لاگین
    }

}
