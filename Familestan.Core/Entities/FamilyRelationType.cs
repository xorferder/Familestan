namespace Familestan.Core.Entities
{
    public class FamilyRelationType : BaseEntity
    {
        public long FamilyRelationTypeId { get; set; }

        public required string FamilyRelationTypeName { get; set; } // عنوان رابطه (مثلاً پدر، مادر، برادر)
        public required string FamilyRelationCategory { get; set; } // دسته‌بندی (مثلاً نسب خونی، سببی)

        public ICollection<FamilyRelation> FamilyRelations { get; set; } = new List<FamilyRelation>();
        public ICollection<FamilyClaim> FamilyClaims { get; set; } = new List<FamilyClaim>();
    }
}
