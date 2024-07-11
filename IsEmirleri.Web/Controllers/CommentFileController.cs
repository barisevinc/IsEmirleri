using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class CommentFileController : Controller
    {
        private readonly ICommentFileService _commentFileService;

        public CommentFileController(ICommentFileService commentFileService)
        {
            _commentFileService = commentFileService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
