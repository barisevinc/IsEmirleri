using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {

            return Json(new { data = _projectService.GetAllByCustomerId()}) ;
        }

        public IActionResult FillUsers()
        {
            return Json(new {data = _projectService.FillUsers() });
        }


        [HttpPost]
        public IActionResult Add(Project project,List<int> userIds)
        {
          return Ok(_projectService.AddProject(project, userIds));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {

            return Ok(_projectService.Delete(id));
        }

        [HttpPost]
        public IActionResult Update(Project project, List<int> userIds)
        {
          
            return Ok(_projectService.Update(project, userIds));
        }


       
        public IActionResult GetById(int id)
        {
            return Ok(_projectService.GetByProjectId(id));
        }



    }
}
