namespace Familestan.Core.Entities
{
    public class Comment : BaseEntity
    {
        public long CommentId { get; set; }
        
        public required string CommentEncryptedContent { get; set; }
        
        public long CommentPostId { get; set; }
        public required Post CommentPost { get; set; }

        public long CommentMemberId { get; set; }
        public required Member CommentMember { get; set; }
    }
}
