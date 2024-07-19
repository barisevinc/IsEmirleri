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
            
            return Ok(_projectService.AddProject(project, usersEmails));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {

            return Ok(_projectService.Delete(id));
        }

        [HttpPost]
        public IActionResult Update(ProjectUpdateDto updateDto)
        {
            var updatedProject = _projectService.UpdateProject(updateDto);
            return Ok(updatedProject);
        }



        //[HttpGet]
        //public IActionResult GetById(int id)
        //{
        //    var project = _projectService.GetById(id);
        //    if (project == null)
        //    {
        //        return NotFound("Proje bulunamadı.");
        //    }

        //    var projectDto = new ProjectUpdateDto
        //    {
        //        Id = project.Id,
        //        Name = project.Name,
        //        Description = project.Description,
        //        UserEmails = project.Users.Select(u => u.Email).ToList()
        //    };

        //    return Ok(projectDto);
        //}



    }
}
