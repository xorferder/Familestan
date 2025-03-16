namespace Familestan.Core.Entities
{
    public class Permission
    {
        public long? PermissionId { get; set; }
        public string? PermissionName { get; set; } = string.Empty;
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
