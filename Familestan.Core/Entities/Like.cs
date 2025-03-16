namespace Familestan.Core.Entities
{
    public class Like : BaseEntity
    {
        public long? LikeMemberId { get; set; }
        public Member? LikeMember { get; set; }
        public long? LikePostId { get; set; }
        public Post? LikePost { get; set; }
    }
}