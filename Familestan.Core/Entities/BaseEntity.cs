namespace Familestan.Core.Entities
{
    public abstract class BaseEntity
    {
        public long? Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}