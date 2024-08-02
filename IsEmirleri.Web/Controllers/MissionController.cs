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

        public IActionResult GetById(int id) { 
        
            return Ok(_missionService.GetById(id));
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
