using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.MissionDTO;
using IsEmirleri.DTO.MissionDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class MissionService : Service<Mission>, IMissionService
    {
        private readonly IRepository<Mission> _repository;
        private readonly IService<AppUser> _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStatusService _statusService;

        public MissionService(IRepository<Mission> repository, IHttpContextAccessor httpContextAccessor, IStatusService statusService, IUserService userService) : base(repository)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _statusService = statusService;
        }

        public Mission AddMission(Mission mission, List<int> userIds)
        {
            var addedMission = _repository.Add(mission);
           

            if (userIds != null && userIds.Count > 0)
            {
                var users = _userService.GetAll(u => userIds.Contains(u.Id)).ToList();

                foreach (var user in users)
                {
                    addedMission.Assignees = users;
                }

                _repository.Update(addedMission);
            }

            return addedMission;
        }

        public IQueryable<Mission> GetAll()
        {
            return _repository.GetAll().Include(x => x.Project).Include(x=>x.Priority).Select(x => new Mission
            {
              Id = x.Id,
              Title= x.Title,
              Description = x.Description,
              StartDate = x.StartDate, 
              EndDate = x.EndDate,
              Project = x.Project,
              Priority= x.Priority,
              Status= x.Status

            });
        }

       

        public List<MissionDto> GetAllMission()
        {
            var mission = _repository.GetAll()
           .Include(p => p.Assignees)
           .Include(p => p.Status)
           .Include(p => p.Priority)
           .Include(p => p.Comments)
           .ThenInclude(p => p.User)
           .Include(p => p.Project)
           .ThenInclude(p => p.Users)
           .Where(p => p.Id == missionId)
           .Select(p => new MissionGetByDto
           {
               Id = p.Id,
               Title = p.Title,
               Description = p.Description,
               StartDate = p.StartDate,
               EndDate = p.EndDate,
               DateCreated = p.DateCreated,
               DateUpdated = p.DateUpdated,
               StatusName = p.Status.Name,
               PriorityName = p.Priority.Name,
               ProjectName = p.Project.Name,
               ProjectId = p.Project.Id,
               AssigneeEmails = p.Assignees.Select(a => a.Email).ToList(),
               EmailNotification = p.EmailNotification,
               SmsNotification = p.SmsNotification,
               Comments = p.Comments.ToList()

           })
           .FirstOrDefault();


    }
}
