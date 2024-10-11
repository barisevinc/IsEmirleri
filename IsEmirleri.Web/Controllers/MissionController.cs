using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
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

        public IActionResult GetAll()
        {

            return Json(new { data = _missionService.GetAll() });

        }
        public IActionResult Raports()
        {
            return View();
        } 

        public IActionResult GetAllCard()
        {
            var item = _missionService.GetAllMission();

            return Json(item);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Mission mission, List<int> userIds, bool emailNotification)
        {
            var addedMission = await _missionService.AddMission(mission, userIds, emailNotification);
            return Ok(addedMission);
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

        public IActionResult GetById(int id)
        {

            return Ok(_missionService.GetByMissionId(id));
        }

        public IActionResult Update(Mission mission)
        {

            return Ok(_missionService.Update(mission));
        }

        public IActionResult Delete(int id)
        {

            return Ok(_missionService.Delete(id));
        }

        public IActionResult Board()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UpdateStatus(int taskId, int statusId)
        {
            var result = _missionService.UpdateStatus(taskId, statusId);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Durum güncellenirken bir hata oluştu." });
            }
        }

        [HttpGet("{missionId}/duration")]
        public ActionResult<TimeSpan> GetMissionDuration(int missionId)
        {

            return Ok(_missionService.GetMissionDuration(missionId));

        }

        [HttpPost]
        public IActionResult StartMission(int missionId)
        {

            return Ok(_missionService.StartMission(missionId));
        }

        [HttpPost]
        public IActionResult StopMission(int missionId)
        {

            return Ok(_missionService.StopMission(missionId));
        }

        [HttpPost]
        public IActionResult CompleteMission(int missionId)
        {

            return Ok(_missionService.CompleteMission(missionId));
        }

        [HttpGet("Mission/CompletionTime/{userId}")]
        public IActionResult CompletionTime(int userId)
        {
            return View(userId);
        }
        [HttpGet]
        public IActionResult CompletionTimes(int userId)
        {
            var completionTimes = _missionService.GetMissionCompletionTimes(userId);
            return Json(new { data = completionTimes });
        }
        [HttpGet("GetAverageCompletionTime")]
        public IActionResult GetAverageCompletionTime(int userId)
        {
            var avgTime = _missionService.GetAverageCompletionTime(userId);
            return Ok(new { AverageCompletionTime = avgTime.ToString() });
        }
        public IActionResult TaskDistribution()
        {
            return View();
        }
        [HttpGet("GetTaskStatusDistribution")]
        public IActionResult GetTaskStatusDistribution()
        {
            var report = _missionService.GetTaskStatusDistribution();
            return Ok(report);
        }


        [HttpGet]
        public IActionResult UserEfficiency(int userId)
        {
         var efficiency = _missionService.GetUserMissionEfficiency(userId);
            return Json(efficiency);
        }

      
        public IActionResult Productivity(int id)
        {
           
            return View(id);
        }


    }
}