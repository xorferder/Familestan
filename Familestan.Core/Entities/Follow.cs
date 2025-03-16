namespace Familestan.Core.Entities
{
    public class Follow : BaseEntity
    {
        public long FollowId { get; set; }

        public long FollowFollowerId { get; set; } // کسی که فالو می‌کند
        public required Member FollowFollower { get; set; }

        public long FollowFollowingId { get; set; } // کسی که فالو شده
        public required Member FollowFollowing { get; set; }

        public DateTime FollowCreatedAt { get; set; } = DateTime.UtcNow;
    }
}
