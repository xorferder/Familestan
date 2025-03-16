namespace Familestan.Core.Entities
{
    public class FamilyRelation : BaseEntity
    {
        public long FamilyRelationId { get; set; }

        public long FamilyRelationMember1Id { get; set; }
        public required Member FamilyRelationMember1 { get; set; }

        public long FamilyRelationMember2Id { get; set; }
        public required Member FamilyRelationMember2 { get; set; }

        public long FamilyRelationTypeId { get; set; }
        public required FamilyRelationType FamilyRelationType { get; set; }

        public bool FamilyRelationIsConfirmed { get; set; } = false;

        public DateTime FamilyRelationCreatedAt { get; set; } = DateTime.UtcNow;
    }
}
