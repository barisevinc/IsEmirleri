using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class NotificationService : Service<Notification>, INotificationService
    {
       private readonly IRepository<Notification> _notificationRepository;
        private readonly IHttpContextAccessor   _contextAccessor;



        public NotificationService(IRepository<Notification> notificationRepository, IHttpContextAccessor contextAccessor) : base(notificationRepository)
        {
            _notificationRepository = notificationRepository;
            _contextAccessor = contextAccessor;
        }

        public List<Notification> GetAllNotification()
        {
            int userId = 3;
          return  _notificationRepository.GetAll(u => u.UserId == userId).OrderByDescending(x=>x.DateCreated).ToList();

        }

        public void NewNotificationMission(int userId)
        {
            Notification notification = new Notification();
            notification.UserId = userId;
            notification.Description = "Yeni Görev Atandı";
            notification.Status = true;
            notification.Type = "Bildirim";
            notification.Icon = "mdi-book-alert-outline";
            _notificationRepository.Add(notification);
            _notificationRepository.Save();

        }

        public void NewNotificationProject(int userId)
        {
            Notification notification = new Notification();
            notification.UserId = userId;
            notification.Description = "Yeni Bir Projeye Atandınız";
            notification.Status = true;
            notification.Type = "Bildirim";
            notification.Icon = "mdi-projector-screen";
            _notificationRepository.Add(notification);
            _notificationRepository.Save();
        }

        public void NotificationRead(int userId)
        {
            _notificationRepository.GetAll(u => u.UserId == userId && u.Status == true).ToList().ForEach(x=>x.Status=false);
            _notificationRepository.Save();
        }

        public int NotificationWithNotRead(int userId)
        {
           return _notificationRepository.GetAll(u => u.UserId == userId && u.Status == true).Count();
        }
    }
}
