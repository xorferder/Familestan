namespace Familestan.Core.Entities
{
    public class Follow : BaseEntity
    {
        public long? FollowFollowerId { get; set; }
        public Member? FollowFollower { get; set; }
        public long? FollowFollowingId { get; set; }
        public Member? FollowFollowing { get; set; }
    }
}