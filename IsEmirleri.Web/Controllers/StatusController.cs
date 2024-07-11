using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace IsEmirleri.Web.Controllers
{
    [Authorize(Roles = "Admin, Superadmin")]
    public class StatusController : Controller
    {
        private readonly IStatusService _status;

        public StatusController(IStatusService statusService)
        {
            _status = statusService;
        }

        public IActionResult Index()
        {
            ViewBag.UserId = 3;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value);
                ViewBag.UserId = userId;
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }



        public IActionResult GetAll()
        {
            return Json(new { data = _status.GetAllStatus() });
        }

        [HttpPost]
        public IActionResult Add(MissionStatus missionStatus)
        {

            return Ok(_status.Add(missionStatus));
        }

        [HttpPost]
        public IActionResult Delete(MissionStatus missionStatus)
        {
            return Ok(_status.HardDelete(missionStatus.Id));

        }

        [HttpPost]
        public IActionResult Update(MissionStatus missionStatus)
        {

            return Ok(_status.Update(missionStatus));
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_status.GetById(id));
        }


    }
}
