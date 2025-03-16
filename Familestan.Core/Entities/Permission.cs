namespace Familestan.Core.Entities
{
    public class Permission : BaseEntity
    {
        public long PermissionId { get; set; }
        
        public required string PermissionName { get; set; } // نام دسترسی
        
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
