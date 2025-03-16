namespace Familestan.Core.Entities
{
    public class FamilyRelation : BaseEntity
{
    public long? FamilyRelationId { get; set; } // شناسه رابطه
    public long? Member1Id { get; set; } // شخص اول
    public long? Member2Id { get; set; } // شخص دوم
    public long? FamilyRelationTypeId { get; set; } // نوع رابطه

    public bool? IsConfirmed { get; set; } // آیا تأیید شده است؟
    public DateTime? ConfirmedAt { get; set; } // زمان تأیید

    // ارتباطات
    public Member? Member1 { get; set; }
    public Member? Member2 { get; set; }
    public FamilyRelationType? FamilyRelationType { get; set; }
}

}