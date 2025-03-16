namespace Familestan.Core.Entities
{
    public class Log : BaseEntity
    {
        public long LogId { get; set; }

        public long LogUserId { get; set; } // کاربری که لاگ ایجاد کرده
        public required User LogUser { get; set; }

        public required string LogAction { get; set; } // نام اکشن ثبت شده
        public required string LogDescription { get; set; } // توضیحات لاگ
        public required string LogIPAddress { get; set; } // IP کاربر

        public DateTime LogCreatedAt { get; set; } = DateTime.UtcNow;
    }
}
