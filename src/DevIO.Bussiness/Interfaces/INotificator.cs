using DevIO.Bussiness.Notifications;
using System.Collections.Generic;

namespace DevIO.Bussiness.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}
