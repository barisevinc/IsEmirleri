using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class TaskHistoryController : Controller
    {
        private readonly ITaskHistoryService _taskHistoryService;

        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
