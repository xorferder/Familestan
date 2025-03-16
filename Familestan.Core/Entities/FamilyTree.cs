namespace Familestan.Core.Entities
{
    public class FamilyTree : BaseEntity
    {
        public long? FamilyTreeId { get; set; }
        public long? MemberId { get; set; } // صاحب شجره‌نامه
        public long? RootMemberId { get; set; } // نقطه شروع درخت

        public bool? IsPublic { get; set; } // آیا این شجره‌نامه عمومی است؟

        // ارتباطات
        public Member? Member { get; set; }
        public Member? RootMember { get; set; }
    }

}