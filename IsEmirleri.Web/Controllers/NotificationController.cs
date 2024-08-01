using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPut]
        public async Task<IActionResult> NotificationRead()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var client = _httpClientFactory.CreateClient();
            try
            {
                var jsonData = JsonConvert.SerializeObject(userId);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.GetAsync("https://localhost:7207/api/Notification/NotificationRead/" + userId);
                if (response.IsSuccessStatusCode)
                {
                    return NoContent();

                }
            }
            catch (Exception ex) { 
                    return BadRequest();
                
            }
            return NoContent();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    try
        //    {
        //        var response = await client.GetAsync("https://localhost:7207/api/Notification");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonData = await response.Content.ReadAsStringAsync();
        //            var value = JsonConvert.DeserializeObject<List<Notification>>(jsonData);
        //            TempData["success"] = $"api açık";

        //            return Ok(value);

        //        }
        //    }
        //    catch (Exception ex) {
        //        TempData["success"] = $"api kapalı";
        //        List<Notification> list = new List<Notification>();

        //        return BadRequest(list);

        //    }

        //    return View();

        //}
    }
}
