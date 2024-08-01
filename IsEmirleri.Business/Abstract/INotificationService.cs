using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface INotificationService:IService<Notification>
    {
        List<Notification> GetAllNotification(int userId);
        void NotificationRead(int userId);
        void NewNotificationMission(int userId);
        void NewNotificationProject(int userId);
        int NotificationWithNotRead(int userId);
    }
}
