namespace Familestan.Core.Entities
{
    public class PostWord : BaseEntity
    {
        public long PostWordPostId { get; set; }
        public required Post PostWordPost { get; set; }

        public long PostWordWordId { get; set; }
        public required Word PostWordWord { get; set; }

        public int PostWordFrequency { get; set; } // تعداد تکرار کلمه در پست
    }
}
