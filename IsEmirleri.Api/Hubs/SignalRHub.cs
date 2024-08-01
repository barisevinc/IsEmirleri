using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace IsEmirleri.Api.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly INotificationService _notificationService;

        public SignalRHub(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task SendNotification(int id)
        {
            var value=_notificationService.NotificationWithNotRead(id);
            await Clients.All.SendAsync("NotificationCount", value);
            var notificationList =_notificationService.GetAllNotification(id);
            await Clients.All.SendAsync("NotificationList", notificationList);

        }
    }
}
