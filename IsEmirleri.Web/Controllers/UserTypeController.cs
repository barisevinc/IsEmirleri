using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _userTypeService.GetAllType() });
        }
    }
}
