using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.ProjectDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class ProjectService : Service<Project>, IProjectService
    {
        private readonly IRepository<Project> _repository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ProjectService(IRepository<Project> repository, IRepository<AppUser> userRepository, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }



        public IQueryable<ProjectGetAllDto> GetAllWithUsers()
        {
            var result = _repository.GetAll().Include(p => p.Users)
         .Select(p => new ProjectGetAllDto
         {
             Id = p.Id,
             Name = p.Name,
             Description = p.Description,
             CustomerId = p.CustomerId,

             UserEmails = p.Users
                         .Where(u => u.CustomerId == p.CustomerId)
                         .Select(u => u.Email)
                         .ToList()
         });
            return result;
        }



        public bool Delete(int id)
        {
            _repository.Delete(id);
            return true;
        }



        public IQueryable<AppUser> FillUsers()
        {
            var currentCustomerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);

            var result = _userRepository.GetAll(u =>
                u.CustomerId == currentCustomerId &&
                u.IsDeleted == false &&
                u.UserTypeId != 1 &&
                u.UserTypeId != 2);

            return result;
        }



        public Project AddProject(Project project, List<string> userIds)
        {
            //burada eklenenler sql e geliyor ama webde görünmüyor
            var currentCustomerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            project.CustomerId = currentCustomerId;
            var addedProject = _repository.Add(project);
            Console.WriteLine(userIds.Count);

            if (userIds != null && userIds.Count > 0)
            {
                var users = _userRepository.GetAll()
                    .Where(u => userIds.Contains(u.Email))
                    .ToList();

                //     foreach (var user in users)
                //   {
                addedProject.Users = users;
              //  }

                _repository.Update(addedProject);
            }

            return addedProject;
        }


        public ProjectUpdateDto UpdateProject(ProjectUpdateDto updateDto)
        {

            var project = _repository.GetById(updateDto.Id);


            project.Name = updateDto.Name;
            project.Description = updateDto.Description;


            project.Users.Clear();

            if (updateDto.UserEmails != null && updateDto.UserEmails.Count > 0)
            {
                var users = _userRepository.GetAll()
                    .Where(u => updateDto.UserEmails.Contains(u.Email))
                    .ToList();

                foreach (var user in users)
                {
                    project.Users.Add(user);
                }
            }

            //?
            _repository.Update(project);

            return new ProjectUpdateDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                UserEmails = project.Users.Select(u => u.Email).ToList()
            };
        }




        //public ProjectGetAllDto GetById(int id)
        //{

        //    var project = _repository.GetAll()
        //        .Include(p => p.Users)
        //        .FirstOrDefault(p => p.Id == id);

        //    return new ProjectGetAllDto
        //    {
        //        Id = project.Id,
        //        Name = project.Name,
        //        Description = project.Description,
        //        CustomerId = project.CustomerId,
        //        UserEmails = project.Users.Select(u => u.Email).ToList()
        //    };
        //}

    }
}
