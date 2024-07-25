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

        public IActionResult GetAll()
        {

            return Json(new { data = _projectService.GetAllByCustomerId()}) ;
        }

        public IActionResult FillUsers()
        {
            return Json(new {data = _projectService.FillUsers() });
        }


        [HttpPost]
        public IActionResult Add(Project project,List<string> usersEmails)
        {
            _projectService.AddProject(project, usersEmails);


            return NoContent();
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {

            return Ok(_projectService.Delete(id));
        }

        [HttpPost]
        public IActionResult Update(Project project, string[] usersEmails)
        {
            var updatedProject = _projectService.Update(project, usersEmails);
            return NoContent();
        }


       
        public IActionResult GetById(int id)
        {
            return Ok(_projectService.GetByProjectId(id));
        }



    }
}
