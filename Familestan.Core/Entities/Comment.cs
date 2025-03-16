namespace Familestan.Core.Entities
{
    public class Comment : BaseEntity
    {
        public long? CommentMemberId { get; set; }
        public Member? CommentMember { get; set; }
        public long? CommentPostId { get; set; }
        public Post? CommentPost { get; set; }
        public string? CommentEncryptedContent { get; set; } = string.Empty;
    }
}