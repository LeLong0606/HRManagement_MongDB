using HRManagement.Data;
using HRManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HRManagement.Services.HR
{
    public class NotificationService
    {
        private readonly IMongoCollection<Notification> _notifications;
        public NotificationService(IOptions<ApplicationMongoDB> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _notifications = database.GetCollection<Notification>(settings.Value.CollectionName.Notifications);
        }
        public async Task<Notification> CreateNotificationAsync(Notification notification)
        {
            notification.CreatedAt = DateTime.UtcNow;
            await _notifications.InsertOneAsync(notification);
            return notification;
        }
    }
}
