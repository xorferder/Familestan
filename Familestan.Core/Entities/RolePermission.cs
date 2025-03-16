namespace Familestan.Core.Entities
{
    public class RolePermission : BaseEntity
    {
        public long RolePermissionId { get; set; }

        public long RolePermissionRoleId { get; set; }
        public required Role RolePermissionRole { get; set; }

        public long RolePermissionPermissionId { get; set; }
        public required Permission RolePermissionPermission { get; set; }
    }
}
