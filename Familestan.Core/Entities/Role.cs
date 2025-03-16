namespace Familestan.Core.Entities
{
    public class Role : BaseEntity
    {
        public long RoleId { get; set; }
        
        public required string RoleName { get; set; } // نام نقش
        
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
