using System.ComponentModel.DataAnnotations.Schema;

namespace Familestan.Core.Entities
{
    public class Follow : BaseEntity
    {
        public long FollowId { get; set; }

        [ForeignKey(nameof(FollowFollower))]
        public long FollowFollowerId { get; set; }
        public required Member FollowFollower { get; set; }

        [ForeignKey(nameof(FollowFollowing))]
        public long FollowFollowingId { get; set; }
        public required Member FollowFollowing { get; set; }
    }
}
