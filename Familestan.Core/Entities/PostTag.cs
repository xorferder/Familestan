namespace Familestan.Core.Entities
{
    public class PostTag : BaseEntity
    {
        public long? PostTagPostId { get; set; }
        public Post? PostTagPost { get; set; }
        public long? PostTagTagId { get; set; }
        public Tag? PostTagTag { get; set; }
    }
}