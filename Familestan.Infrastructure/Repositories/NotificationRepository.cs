using Microsoft.EntityFrameworkCore;
using Familestan.Core.Entities;
using Familestan.Infrastructure.Data;

namespace Familestan.Infrastructure.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(long receiverId)
        {
            return await _context.Notifications
                .Where(n => n.NotificationReceiverId == receiverId && (n.IsDeleted == false))
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(long notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.NotificationIsRead = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
