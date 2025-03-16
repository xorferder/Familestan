namespace Familestan.Core.Entities
{
    public class OtpVerification
    {
        public long OtpId { get; set; } // کلید اصلی
        public string OtpCode { get; set; } = string.Empty; // کد OTP
        public string OtpTarget { get; set; } = string.Empty; // ایمیل یا موبایل
        public string OtpType { get; set; } = "Email"; // نوع OTP (ایمیل یا موبایل)
        public DateTime OtpExpiration { get; set; } // تاریخ انقضا
        public bool OtpIsUsed { get; set; } = false; // آیا استفاده شده است؟

        // رابطه با Member
        public long? OtpMemberId { get; set; }
        public Member? OtpMember { get; set; }
    }
}
