using Familestan.Core.Entities;
using Familestan.Infrastructure.Repositories;

namespace Familestan.Infrastructure.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(long receiverId, string type, string message);
        Task<IEnumerable<Notification>> GetNotificationsAsync(long userId);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task SendNotificationAsync(long receiverId, string type, string message)
        {
            var notification = new Notification
            {
                NotificationReceiverId = receiverId,
                NotificationType = type,
                NotificationMessage = message
            };

            await _notificationRepository.AddAsync(notification);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsAsync(long userId)
        {
            return await _notificationRepository.GetUnreadNotificationsAsync(userId);
        }
    }
}
