namespace Familestan.Core.Entities
{
    public class FamilyTree : BaseEntity
    {
        public long FamilyTreeId { get; set; }

        public long FamilyTreeMemberId { get; set; }
        public required Member FamilyTreeMember { get; set; }

        public long FamilyTreeRootMemberId { get; set; }
        public required Member FamilyTreeRootMember { get; set; } // ریشه‌ی شجره‌نامه

        public DateTime FamilyTreeCreatedAt { get; set; } = DateTime.UtcNow;
    }
}
