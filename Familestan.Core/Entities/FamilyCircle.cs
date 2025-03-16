namespace Familestan.Core.Entities
{
    public class FamilyCircle : BaseEntity
    {
        public long? FamilyCircleId { get; set; }
        public long? MemberId { get; set; } // عضو حلقه
        public long? ConnectedMemberId { get; set; } // عضو متصل شده

        // ارتباطات
        public Member? Member { get; set; }
        public Member? ConnectedMember { get; set; }
    }

}