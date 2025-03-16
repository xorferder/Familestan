namespace Familestan.Core.Entities
{
    public class PostTag : BaseEntity
    {
        public long PostTagPostId { get; set; }
        public required Post PostTagPost { get; set; }

        public long PostTagTagId { get; set; }
        public required Tag PostTagTag { get; set; }
    }
}
