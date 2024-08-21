using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IHomePageService _homePageService;

        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string mail,string subject,string message)
        {
            if (await _homePageService.NewMail(mail,subject,message))
            {
                TempData["success"] = "Mesajınız İletilmiştir, Kısa Süre İçerisinde Size Geri Dönüş Sağlayacağız.";
                return RedirectToAction("index");

            }
            else
            {
                TempData["error"] = "Mesajınız İletilemedi, Lütfen Tekrar Deneyiniz.";
                return RedirectToAction("index");
            }

        }
    }
}
