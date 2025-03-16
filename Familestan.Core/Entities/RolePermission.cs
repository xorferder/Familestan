namespace Familestan.Core.Entities
{
    public class RolePermission
    {
        public long? RolePermissionId { get; set; }
        public long? RoleId { get; set; }
        public long? PermissionId { get; set; }
        public Role? Role { get; set; }
        public Permission? Permission { get; set; }
    }
}
