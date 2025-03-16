using Familestan.Core.Entities;

namespace Familestan.Infrastructure.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(long userId);
        Task MarkAsReadAsync(long notificationId);
    }
}
