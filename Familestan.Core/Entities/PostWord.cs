namespace Familestan.Core.Entities
{
    public class PostWord : BaseEntity
    {
        public long? PostWordId { get; set; } // شناسه‌ی نگاشت بین پست و کلمه
        public long? PostId { get; set; } // ارتباط با پست
        public long? WordId { get; set; } // ارتباط با کلمه

        // روابط
        public Post? Post { get; set; }
        public Word? Word { get; set; }
    }
}