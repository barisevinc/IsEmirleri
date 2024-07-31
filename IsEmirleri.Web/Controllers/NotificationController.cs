using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                var response = await client.GetAsync("https://localhost:7207/api/Notification");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<Notification>>(jsonData);
                    TempData["success"] = $"api açık";

                    return Ok(value);

                }
            }
            catch (Exception ex) {
                TempData["success"] = $"api kapalı";
                List<Notification> list = new List<Notification>();

                return BadRequest(list);

            }

            return View();

        }
    }
}
