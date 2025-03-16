namespace Familestan.Core.Entities
{
    public class Tag : BaseEntity
    {
        public long TagId { get; set; }
        public required string TagName { get; set; }

        public ICollection<PostTag> TagPostTags { get; set; } = new List<PostTag>();
    }
}
