using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class TaskFileController : Controller
    {
        private readonly ITaskFileService _taskFileService;

        public TaskFileController(ITaskFileService taskFileService)
        {
            _taskFileService = taskFileService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
