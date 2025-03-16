namespace Familestan.Core.Entities
{
    public class OtpVerification : BaseEntity
    {
        public long OtpId { get; set; }
        public required string OtpCode { get; set; }
        public required string OtpType { get; set; } // "Email" یا "Phone"
        public required string OtpTarget { get; set; } // ایمیل یا موبایل
        public long? OtpMemberId { get; set; } // ممکنه برای عضو نشده‌ها باشه
        public DateTime OtpExpiration { get; set; }
        public bool OtpIsUsed { get; set; } = false;

        public Member? OtpMember { get; set; } // ارتباط با جدول Member
    }
}
