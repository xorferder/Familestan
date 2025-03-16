using Microsoft.AspNetCore.Identity;

namespace Familestan.Core.Entities
{
    public class Role : IdentityRole<long>
    {
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
