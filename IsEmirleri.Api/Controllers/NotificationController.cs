using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }


        [HttpGet]
        public IActionResult GetAllNotifications()
        {

            return Ok(notificationService.GetAllNotification());
        }
    }
}
