using System.ComponentModel.DataAnnotations;

namespace Familestan.Core.Entities
{
    public class User : BaseEntity
    {
        [Key]  // کلید اصلی مشخص شود
        public long UserId { get; set; }

        public required string UserFirstName { get; set; }
        public required string UserLastName { get; set; }
        public required string UserEncryptedEmail { get; set; }
        public required string UserEncryptedPhoneNumber { get; set; }
        public bool UserIsActive { get; set; } = true;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
