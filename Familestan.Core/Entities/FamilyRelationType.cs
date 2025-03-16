namespace Familestan.Core.Entities
{
    public class FamilyRelationType : BaseEntity
    {
        public long? FamilyRelationTypeId { get; set; } // شناسه نوع رابطه
        public string? FamilyRelationTypeName { get; set; } = string.Empty; // نام رابطه (مثلاً پدر، مادر، برادر، خواهر)
        public string? FamilyRelationCategory { get; set; } = string.Empty; // دسته‌بندی (مثلاً خونی، سببی، سابق، ...)

        public ICollection<FamilyRelation> FamilyRelations { get; set; } = new List<FamilyRelation>();
        public ICollection<FamilyClaim> FamilyClaims { get; set; } = new List<FamilyClaim>();
    }

}