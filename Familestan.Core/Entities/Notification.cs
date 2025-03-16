namespace Familestan.Core.Entities
{
    public class Notification : BaseEntity
    {
        public long NotificationId { get; set; }
        public long NotificationReceiverId { get; set; } // کاربری که نوتیفیکیشن رو دریافت می‌کنه
        public required string NotificationType { get; set; } // مثلا "NewFollow", "NewComment", "NewMessage"
        public required string NotificationMessage { get; set; } 
        public bool NotificationIsRead { get; set; } = false; // برای مشخص کردن خوانده شدن
        public DateTime NotificationCreatedAt { get; set; } = DateTime.UtcNow;
        
        public Member NotificationReceiver { get; set; } = null!; // ارتباط با جدول Member
    }
}
