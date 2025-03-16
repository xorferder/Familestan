namespace Familestan.Core.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<long>
    {
        public string? UserFirstName { get; set; } = string.Empty;
        public string? UserLastName { get; set; } = string.Empty;
        public string? UserBio { get; set; } = string.Empty;
        public bool? UserIsVerified { get; set; }
        public bool? UserIsPrivate { get; set; }
        public string? UserEncryptedEmail { get; set; } = string.Empty;
        public string? UserEncryptedPhoneNumber { get; set; } = string.Empty;
        public ICollection<Member> UserMembers { get; set; } = new List<Member>();

        // اضافه کردن فیلدهای BaseEntity
        public bool? IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}