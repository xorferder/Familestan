namespace Familestan.Core.Entities
{
    public class FamilyClaim : BaseEntity
    {
        public long FamilyClaimId { get; set; }

        public long FamilyClaimClaimantId { get; set; }
        public required Member FamilyClaimClaimant { get; set; }

        public long FamilyClaimTargetMemberId { get; set; }
        public required Member FamilyClaimTargetMember { get; set; }

        public long FamilyClaimRelationTypeId { get; set; }
        public required FamilyRelationType FamilyClaimRelationType { get; set; }

        public bool FamilyClaimIsVerified { get; set; } = false;
        public DateTime FamilyClaimCreatedAt { get; set; } = DateTime.UtcNow;
    }
}
