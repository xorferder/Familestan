namespace Familestan.Core.Entities
{
    public class Like : BaseEntity
    {
        public long LikeId { get; set; }

        public long LikePostId { get; set; }
        public required Post LikePost { get; set; }

        public long LikeMemberId { get; set; }
        public required Member LikeMember { get; set; }
    }
}
