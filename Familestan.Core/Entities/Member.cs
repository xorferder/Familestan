namespace Familestan.Core.Entities
{
    public class Member : BaseEntity
    {
        public long? MemberUserId { get; set; }
        public User? MemberUser { get; set; }
        public string? MemberFirstName { get; set; } = string.Empty;
        public string? MemberLastName { get; set; } = string.Empty;
        public bool? MemberIsVerified { get; set; }
        public bool? MemberIsPrivate { get; set; }
        public string? MemberEncryptedEmail { get; set; } = string.Empty;
        public string? MemberEncryptedPhoneNumber { get; set; } = string.Empty;
    }
}