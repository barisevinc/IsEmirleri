using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
