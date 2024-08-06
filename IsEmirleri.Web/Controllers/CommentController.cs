using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromBody]Comment comment)
        {
            if (comment == null)
            {
                return BadRequest("Yorum satırı boş lütfen yorum yazınız.");
            }
            return Ok(_commentService.AddComment(comment));
        }
    }
}
