namespace Familestan.Core.Entities
{
    public class Member : BaseEntity
{
    public long MemberId { get; set; }
    public required string MemberFirstName { get; set; }
    public required string MemberLastName { get; set; }
    public string? MemberEncryptedEmail { get; set; }
    public string? MemberEncryptedPhoneNumber { get; set; }
    public bool MemberIsVerified { get; set; } = false;
    public bool MemberIsPrivate { get; set; } = false;
    public string? MemberPasswordHash { get; set; }  // پسورد هش‌شده

    // ⬇️ این دو فیلد باید حذف شوند
    // public string? MemberOtpCode { get; set; }
    // public DateTime? MemberOtpExpiration { get; set; }

    public ICollection<Post> MemberPosts { get; set; } = new List<Post>();
    public ICollection<Comment> MemberComments { get; set; } = new List<Comment>();
    public ICollection<Like> MemberLikes { get; set; } = new List<Like>();
    public ICollection<Follow> MemberFollowers { get; set; } = new List<Follow>();
    public ICollection<Follow> MemberFollowing { get; set; } = new List<Follow>();
    public ICollection<FamilyRelation> MemberFamilyRelations { get; set; } = new List<FamilyRelation>();
    public ICollection<FamilyClaim> MemberFamilyClaims { get; set; } = new List<FamilyClaim>();
}

}
