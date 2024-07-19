using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace IsEmirleri.Web.Controllers
{
    [Authorize (Roles = "Admin,Superadmin")]
    public class PriorityController : Controller
    {
        private readonly IPriorityService _priorityService;

        public PriorityController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _priorityService.GetAllWithTaskCount() });
        }
       
        public IActionResult GetById(int id) 
        {
          return Ok(_priorityService.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            return Ok(_priorityService.Delete(id));
        }
        [HttpPost]
        public IActionResult Add(Priority priority) 
        {
        
            return Ok(_priorityService.Add(priority));
            

        }
        [HttpPost]
        public IActionResult Update(Priority priority) 
        {
            var item= _priorityService.UpdatePriority(priority);
            return Ok(item);
        }
    }
}
