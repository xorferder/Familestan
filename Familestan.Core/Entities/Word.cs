namespace Familestan.Core.Entities
{
    public class Word : BaseEntity
    {
        public long? WordId { get; set; } // شناسه‌ی یکتا برای هر کلمه
        public string? WordText { get; set; } = string.Empty; // خود کلمه
    }
}