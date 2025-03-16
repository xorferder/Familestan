using Microsoft.AspNetCore.Identity;

namespace Familestan.Core.Entities
{
    public class UserRole : IdentityUserRole<long>
    {
        public long? UserRoleId { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
