using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
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

        public IActionResult GetAll() {

            return Json(new { data = _missionService.GetAll()});

        }

        [HttpPost]
        public IActionResult Add(Mission mission, List<int> userIds)
        {
            return Ok(_missionService.AddMission(mission, userIds));
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
