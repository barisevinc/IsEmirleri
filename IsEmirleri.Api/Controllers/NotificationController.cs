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


            return Ok();
        }

        [HttpGet("NotificationRead/{id}")]

        public IActionResult NotificationRead([FromRoute(Name = "id")] int id) { 
        

            notificationService.NotificationRead(id);

            return Ok();
        
        }

        [HttpPost("{id:int}")]
        public IActionResult NewNotificationMission([FromRoute(Name = "id")] int id)
        {
            notificationService.NewNotificationMission(id);
            return StatusCode(201);
        }


        [HttpPost("NewNotificationProject/{id}")]
        public IActionResult NewNotificationProject([FromRoute(Name = "id")] int id)
        {
            notificationService.NewNotificationProject(id);
            return StatusCode(201);
        }

        [HttpGet("NotificationWithNotRead/{id}")]
        public IActionResult NotificationWithNotRead( int id)
        {
            
            return Ok(notificationService.NotificationWithNotRead(id));

        }
    }
}
