using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Cadastro.Domain.Helpers;

namespace Cadastro.Domain.Interfaces.Notifications
{
    public interface INotificationService
    {
        // Feito

        [Write(false)]
        IReadOnlyCollection<Notification> Notifications { get; }

        [Write(false)]
        bool Validar { get; }

        void AddNotification(IReadOnlyCollection<Notification> notifications);

        void ClearNotifications();

    }
}
