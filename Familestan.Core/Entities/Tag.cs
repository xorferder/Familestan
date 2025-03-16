namespace Familestan.Core.Entities
{
    public class Tag : BaseEntity
    {
        public string? TagName { get; set; } = string.Empty;
        public ICollection<PostTag> TagPostTags { get; set; } = new List<PostTag>();
    }
}