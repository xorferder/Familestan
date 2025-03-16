namespace Familestan.Core.Entities
{
    public class FamilyClaim : BaseEntity
    {
        public long? FamilyClaimId { get; set; } // شناسه ادعا
        public long? ClaimantId { get; set; } // شخص ادعا کننده
        public long? TargetMemberId { get; set; } // هدف ادعا
        public long? FamilyRelationTypeId { get; set; } // نوع رابطه

        public bool? IsApproved { get; set; } // آیا تأیید شده؟
        public bool? IsRejected { get; set; } // آیا رد شده؟

        public DateTime? ApprovedAt { get; set; } // زمان تأیید
        public DateTime? RejectedAt { get; set; } // زمان رد شدن

        // ارتباطات
        public Member? Claimant { get; set; } // کسی که ادعا کرده
        public Member? TargetMember { get; set; } // فردی که مورد ادعا قرار گرفته
        public FamilyRelationType? FamilyRelationType { get; set; }
    }

}