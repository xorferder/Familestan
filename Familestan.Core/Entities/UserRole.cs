namespace Familestan.Core.Entities
{
    public class UserRole : BaseEntity
    {
        public long UserRoleId { get; set; }

        public long UserRoleUserId { get; set; }
        public required User UserRoleUser { get; set; }

        public long UserRoleRoleId { get; set; }
        public required Role UserRoleRole { get; set; }
    }
}
