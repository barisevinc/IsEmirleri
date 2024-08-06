using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class MissionController : Controller
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll() {

            return Json(new { data = _missionService.GetAll()});

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

        public IActionResult GetById(int id) { 
        
            return Ok(_missionService.GetByMissionId(id));
        }

        public IActionResult Update(Mission mission) { 

            return Ok(_missionService.Update(mission));
        }

        public IActionResult Delete(int id) { 
        
            return Ok(_missionService.Delete(id));
        }
    }
}
