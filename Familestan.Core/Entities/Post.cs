namespace Familestan.Core.Entities
{
    public class Post : BaseEntity
    {
        public long PostId { get; set; }

        public long PostMemberId { get; set; }
        public required Member PostMember { get; set; }

        public required string PostEncryptedContent { get; set; } // محتوای پست رمزنگاری‌شده
        public bool PostIsPublic { get; set; } = true;

        public DateTime PostCreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Media> PostMediaFiles { get; set; } = new List<Media>();
        public ICollection<Comment> PostComments { get; set; } = new List<Comment>();
        public ICollection<Like> PostLikes { get; set; } = new List<Like>();
        public ICollection<PostTag> PostPostTags { get; set; } = new List<PostTag>();
    }
}
