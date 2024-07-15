using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
using IsEmirleri.DTO.ProjectDTOs;
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

        public IActionResult GetAll(int customerId)
        {

            return Json(new { data = _projectService.GetAllWithUsers() });
        }

        public IActionResult FillUsers()
        {
            return Json(new {data = _projectService.FillUsers() });
        }

        [HttpPost]
        public IActionResult Add(Project project,List<string> usersEmails)
        {
            _projectService.AddProject(project, usersEmails);
            return Ok();
        }


        public IActionResult Update(Project project)
        {
            return Ok(_projectService.Update(project));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {

            return Ok(_projectService.Delete(id));
        }



        //[HttpPost]
        //public IActionResult Add(Project project)
        //{

        //    return Ok(_projectService.Add(project));
        //}


        //public IActionResult GetAll()
        //{
        //    var result = _projectService.GetAllWithUsers().ToList();
        //    return Json(new {data = result});
        //}
    }
}
