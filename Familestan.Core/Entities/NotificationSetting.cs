namespace Familestan.Core.Entities
{
    public class NotificationSetting : BaseEntity
    {
        public long NotificationSettingId { get; set; }
        public long NotificationSettingUserId { get; set; } 
        public bool ReceiveFollowNotifications { get; set; } = true;
        public bool ReceiveCommentNotifications { get; set; } = true;
        public bool ReceiveMessageNotifications { get; set; } = true;
        
        public Member NotificationSettingUser { get; set; } = null!;
    }
}
