using BCrypt.Net;
using Familestan.Core.Entities;
using Familestan.Core.Models;
using Familestan.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Familestan.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IConfiguration _configuration;

        public MemberService(IMemberRepository memberRepository, IConfiguration configuration)
        {
            _memberRepository = memberRepository;
            _configuration = configuration;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            // چک کردن وجود ایمیل
            var existingMember = (await _memberRepository.FindAsync(m => m.MemberEncryptedEmail == dto.Email)).FirstOrDefault();
            if (existingMember != null)
            {
                return false; // ایمیل قبلاً ثبت شده
            }

            // ایجاد عضو جدید با مقدار پیش‌فرض `"-"` برای `FirstName` و `LastName`
            var member = new Member
            {
                MemberFirstName = string.IsNullOrWhiteSpace(dto.FirstName) ? "-" : dto.FirstName,
                MemberLastName = string.IsNullOrWhiteSpace(dto.LastName) ? "-" : dto.LastName,
                MemberEncryptedEmail = dto.Email,
                MemberPasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // هش کردن رمزعبور
                MemberIsVerified = false,
                MemberOtpCode = new Random().Next(100000, 999999).ToString(), // ایجاد OTP
                MemberOtpExpiration = DateTime.UtcNow.AddMinutes(5)
            };

            await _memberRepository.AddAsync(member);

            // ارسال کد OTP (در آینده این بخش را با ارسال ایمیل ادغام می‌کنیم)
            Console.WriteLine($"OTP برای {dto.Email}: {member.MemberOtpCode}");

            return true;
        }

        public async Task<bool> VerifyOtpAsync(VerifyOtpDto dto)
        {
            var members = await _memberRepository.FindAsync(m => m.MemberEncryptedEmail == dto.Email);
            var member = members.FirstOrDefault();

            if (member == null || member.MemberOtpCode != dto.OtpCode || member.MemberOtpExpiration < DateTime.UtcNow)
            {
                return false; // کد نامعتبر یا منقضی شده
            }

            member.MemberIsVerified = true;
            member.MemberOtpCode = null;
            member.MemberOtpExpiration = null;

            await _memberRepository.UpdateAsync(member);
            return true;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var member = (await _memberRepository.FindAsync(m => m.MemberEncryptedEmail == dto.Email)).FirstOrDefault();

            if (member == null || !BCrypt.Net.BCrypt.Verify(dto.Password, member.MemberPasswordHash))
            {
                return null; // ایمیل یا رمزعبور اشتباه است
            }

            var jwtService = new JwtService(_configuration);
            return jwtService.GenerateToken(member);
        }

    }
}
