namespace Familestan.Core.Entities
{
    public class Post : BaseEntity
    {
        public long? PostMemberId { get; set; }
        public Member? PostMember { get; set; }
        public string? PostEncryptedContent { get; set; } = string.Empty;
        public ICollection<Media> PostMediaFiles { get; set; } = new List<Media>();
        public ICollection<Comment> PostComments { get; set; } = new List<Comment>();
        public ICollection<Like> PostLikes { get; set; } = new List<Like>();
        public ICollection<PostTag> PostPostTags { get; set; } = new List<PostTag>();
    }
}
