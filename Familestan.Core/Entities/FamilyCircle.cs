namespace Familestan.Core.Entities
{
    public class FamilyCircle : BaseEntity
    {
        public long FamilyCircleId { get; set; }

        public long FamilyCircleMemberId { get; set; }
        public required Member FamilyCircleMember { get; set; }

        public long FamilyCircleConnectedMemberId { get; set; }
        public required Member FamilyCircleConnectedMember { get; set; }

        public DateTime FamilyCircleCreatedAt { get; set; } = DateTime.UtcNow;
    }
}
