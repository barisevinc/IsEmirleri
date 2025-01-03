﻿using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace IsEmirleri.Web.Controllers
{
    [Authorize(Roles = "Admin, Superadmin, User")]
    public class StatusController : Controller
    {
        private readonly IStatusService _status;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StatusController(IStatusService statusService, IHttpContextAccessor httpContextAccessor)
        {
            _status = statusService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
    
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
            return Json(new { data = _status.GetAllByStatus() });
        }

        [HttpPost]
        public IActionResult Add(MissionStatus missionStatus)
        {
         

            return Ok(_status.Add(missionStatus));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok(_status.Delete(id));

        }

        [HttpPost]
        public IActionResult Update(MissionStatus status)
        {

            return Ok(_status.Update(status));
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_status.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAllLog()
        {
            return Json(new { data = _status.GetAllLoginStatus() });
        }

    }
}
