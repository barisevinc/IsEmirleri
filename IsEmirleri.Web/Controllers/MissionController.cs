using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class MissionController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMissionService _missionService;


        public MissionController(IMissionService missionService, IHttpClientFactory httpClientFactory = null)
        {
            _missionService = missionService;
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll() {


            try
            {
                int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var client = httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://localhost:7207/api/Mission/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<Mission>>(jsonData);
                    return Json(new { data = values });
                }
            }
            catch (Exception ex) {
                return BadRequest("apiKapalı");
            }

            return Json(new { data = _missionService.GetAll() });

        }

        public IActionResult GetAllCard()
        {
            var item = _missionService.GetAllMission();

            return Json( item);

        }

        public IActionResult Add(Mission mission)
        {
            try
            {

                return Ok(_missionService.Add(mission));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public IActionResult UpdateDescription(int missionId, string description)
        {

            var result = _missionService.UpdateMissionDescription(missionId, description);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Güncelleme sırasında bir hata oluştu." });
            }


        }

        //[HttpPost]
        //public IActionResult GetTaskBystatus(int ids)
        //{
        //    return Json(new { data = _missionService.GetTaskBystatus(ids) });
        //}

        
        public IActionResult GetById(int id) { 
        
            return Ok(_missionService.GetByMissionId(id));
        }

        public IActionResult Update(Mission mission) { 

            return Ok(_missionService.Update(mission));
        }

        public IActionResult Delete(int id) { 
        
            return Ok(_missionService.Delete(id));
        }

        public IActionResult Board() {

            return View();
        }


    }
}
