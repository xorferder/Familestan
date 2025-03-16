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
        private readonly OtpVerificationRepository _otpVerificationRepository;
        private readonly IConfiguration _configuration;

        public MemberService(IMemberRepository memberRepository, IConfiguration configuration, OtpVerificationRepository otpVerificationRepository)
        {
            _memberRepository = memberRepository;
            _configuration = configuration;
            _otpVerificationRepository = otpVerificationRepository;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            // بررسی وجود ایمیل در دیتابیس
            var existingMember = (await _memberRepository.FindAsync(m => m.MemberEncryptedEmail == dto.Email)).FirstOrDefault();

            if (existingMember != null)
            {
                if (existingMember.MemberIsVerified)
                {
                    throw new Exception("این ایمیل قبلاً ثبت و تأیید شده است.");
                }

                // اگر کاربر ثبت شده ولی تأیید نشده، اطلاعات را به‌روز کنیم و OTP جدید بفرستیم
                existingMember.MemberFirstName = dto.FirstName ?? "-";
                existingMember.MemberLastName = dto.LastName ?? "-";
                existingMember.MemberPasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password ?? "Default@123");

                await _memberRepository.UpdateAsync(existingMember);

                // ارسال OTP جدید
                await GenerateOtpAsync(existingMember.MemberEncryptedEmail ?? "", "Email", existingMember.MemberId);

                return true;
            }

            // اگر ایمیل جدید باشد، عضو جدید ثبت کنیم
            var newMember = new Member
            {
                MemberFirstName = dto.FirstName ?? "-",
                MemberLastName = dto.LastName ?? "-",
                MemberEncryptedEmail = dto.Email ?? "",
                MemberPasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password ?? "Default@123"),
                MemberIsVerified = false
            };

            await _memberRepository.AddAsync(newMember);

            // ارسال OTP
            await GenerateOtpAsync(newMember.MemberEncryptedEmail ?? "", "Email", newMember.MemberId);

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
        public async Task<string> GenerateOtpAsync(string? target, string type, long? memberId)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentException("Target cannot be null or empty", nameof(target));
            }

            string otpCode = new Random().Next(100000, 999999).ToString();

            // بررسی اگر برای این ایمیل OTP ارسال شده ولی استفاده نشده، غیرفعال شود
            var existingOtp = (await _otpVerificationRepository.FindAsync(o => o.OtpTarget == target && !o.OtpIsUsed)).FirstOrDefault();
            if (existingOtp != null)
            {
                existingOtp.OtpIsUsed = true;
                await _otpVerificationRepository.UpdateAsync(existingOtp);
            }

            // ایجاد رکورد جدید OTP
            var otp = new OtpVerification
            {
                OtpCode = otpCode,
                OtpType = type ?? "Email",
                OtpTarget = target,
                OtpMemberId = memberId ?? 0,
                OtpExpiration = DateTime.UtcNow.AddMinutes(5),
                OtpIsUsed = false
            };

            await _otpVerificationRepository.AddAsync(otp);

            Console.WriteLine($"OTP برای {target}: {otpCode}"); // بعداً به ارسال ایمیل وصل می‌کنیم

            return otpCode;
        }
        public async Task<bool> VerifyOtpAsync(string target, string otpCode)
        {
            if (string.IsNullOrEmpty(target) || string.IsNullOrEmpty(otpCode))
            {
                return false;
            }

            var otp = (await _otpVerificationRepository.FindAsync(o => o.OtpTarget == target && o.OtpCode == otpCode && !o.OtpIsUsed && o.OtpExpiration > DateTime.UtcNow)).FirstOrDefault();

            if (otp == null)
            {
                return false; // OTP نامعتبر یا منقضی شده
            }

            otp.OtpIsUsed = true;
            await _otpVerificationRepository.UpdateAsync(otp);

            // اگر OTP معتبر باشد، کاربر را تأیید کنیم
            var member = (await _memberRepository.FindAsync(m => m.MemberEncryptedEmail == target)).FirstOrDefault();
            if (member != null)
            {
                member.MemberIsVerified = true;
                await _memberRepository.UpdateAsync(member);
            }

            return true;
        }


    }
}

