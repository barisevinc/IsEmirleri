﻿using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.ProjectDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using IsEmirleri.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class ProjectService : Service<Project>, IProjectService
    {
        private readonly IUserService _userService;
        private readonly IRepository<Project> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationService notificationService;
        private readonly IMissionService _missionService;

        public ProjectService(IRepository<Project> repository, IHttpContextAccessor httpContextAccessor, IUserService userService, INotificationService notificationService, IMissionService missionService) : base(repository)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            this.notificationService = notificationService;
            _missionService = missionService;
        }


        //düzenlemeye basınca
        public Project GetByProjectId(int id)
        {
            return _repository.GetAll().Include(p => p.Users).FirstOrDefault(p => p.Id == id);

         
        }


        //her admin sadece bağlı olduğu firmanın proje listesini görebilsin
        public IQueryable<Project> GetAllByCustomerId()
        {

            var currentCustomerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);

            return _repository.GetAll(p => p.CustomerId == currentCustomerId).Include(p => p.Users);
        
        }



        //select2 ddl'yi ilgili userlar ile doldurma
        public IQueryable<AppUser> FillUsers()
        {
            var currentCustomerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);

            var result = _userService.GetAll(u => u.CustomerId == currentCustomerId && u.UserTypeId == 3);

            return result;
        }



        public async Task<Project> AddProject(Project project, List<int> userIds, bool emailNotification, IFormFile file)
        {
            // Müşteri ID'sini al
            var currentCustomerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            project.CustomerId = currentCustomerId;

            // Projeyi ekle
            var addedProject = _repository.Add(project);
            var users = _userService.GetAll(u => userIds.Contains(u.Id)).ToList();
            // Dosya yükleme
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine("wwwroot/files", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                project.FilePath = file.FileName; // Yalnızca dosya adını saklıyoruz
            }

            // Kullanıcıları ekle
            if (userIds != null && userIds.Count > 0)
            {
                

                foreach (var user in users)
                {
                    notificationService.NewNotificationProject(user.Id);
                    addedProject.Users.Add(user); // Kullanıcıları projeye ekle
                }

                _repository.Update(addedProject); // Projeyi güncelle
            }

            // E-posta bildirimleri gönder
            if (emailNotification && users.Count > 0)
            {
                var emailTasks = new List<Task>();

                foreach (var user in users)
                {
                    emailTasks.Add(HelperProjectMail.SendProjectAssignedMailAsync(user.Email, project.Name));
                    notificationService.NewNotificationMission(user.Id);
                }

                await Task.WhenAll(emailTasks); // Tüm e-posta gönderme görevlerini bekle
            }

            return addedProject; // Eklenen projeyi döndür
        }


        public Project Update(Project project,List<int> userIds)
        {
            Project asil = base.GetAll(u => u.Id == project.Id).Include(u => u.Users).FirstOrDefault();
            asil.Name = project.Name;
            asil.Description = project.Description;


            asil.Users.Clear();


            foreach (var userId in userIds)
            {
                AppUser user = _userService.GetById(userId);
                if (user != null)
                {
                    asil.Users.Add(user);
                }
            }

            _repository.Update(asil);
            return asil;
        }


        public bool Delete(int id)
        {
            _repository.Delete(id);
            return true;
        }

        public ProjectProgressDto GetProjectProgress(int id)
        {
            var missions = _missionService.GetAllMissionsByProjectId(id);

            var totalMissions = missions.Count();
            var completedMissions = missions.Count(m => m.IsCompleted);
            var ongoingMissions = missions.Count(m => !m.IsCompleted && m.EndDate >= DateTime.Now);
            var delayedMissions = missions.Count(m => !m.IsCompleted && m.EndDate < DateTime.Now);

            var progressDto = new ProjectProgressDto
            {
                ProjectName = _repository.GetAll().FirstOrDefault(p => p.Id == id)?.Name, 
                TotalMissions = totalMissions,
                CompletedMissions = completedMissions,
                OngoingMissions = ongoingMissions,
                DelayedMissions = delayedMissions
            };

            return progressDto;
        }

        public ProjectCountDto ProjectCount(int customerId)
        {
            var projectCount = GetAll().Where(c => c.CustomerId == customerId).Count();
            return new ProjectCountDto
            {
                ProjectCount = projectCount

            };
        }
    }
}
