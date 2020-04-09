using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;
using Cadastro.Domain.Interfaces.Notifications;

namespace Cadastro.Domain.Helpers
{
    // Feito

    public class NotificationService : INotificationService
    {
        private List<Notification> _notifications { get; set; } = new List<Notification>();

        [Write(false)]
        public IReadOnlyCollection<Notification> Notifications { get { return _notifications; } }

        [Write(false)]
        public bool Validar { get { return !_notifications.Any(); } }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }
        public void ClearNotifications()
        {
            _notifications = new List<Notification>();
        }
        public void AddNotification(IReadOnlyCollection<Notification> notifications)    
        {
            _notifications.AddRange(notifications);
        }
    }
}
