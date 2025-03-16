namespace Familestan.Core.Entities
{
    public class Media : BaseEntity
    {
        public long? MediaPostId { get; set; }
        public Post? MediaPost { get; set; }
        public string? MediaUrl { get; set; } = string.Empty;
        public string? MediaType { get; set; } = string.Empty;
    }
}