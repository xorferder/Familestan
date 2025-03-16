namespace Familestan.Core.Entities
{
    public class Media : BaseEntity
    {
        public long MediaId { get; set; }
        
        public required string MediaUrl { get; set; }
        public required string MediaType { get; set; }
        
        public long MediaPostId { get; set; }
        public required Post MediaPost { get; set; }
    }
}
