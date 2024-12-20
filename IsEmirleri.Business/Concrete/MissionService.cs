﻿using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.MissionDTOs;
using IsEmirleri.DTO.MissionDTO;
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
using IsEmirleri.DTO.UserDTOs;
using IsEmirleri.Utility;

namespace IsEmirleri.Business.Concrete
{
    public class MissionService : Service<Mission>, IMissionService
    {
        private readonly IRepository<Mission> _repository;
        private readonly IService<AppUser> _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStatusService _statusService;
        private readonly ITaskHistoryService _taskHistoryService;
        private readonly INotificationService notificationService;

        public MissionService(IRepository<Mission> repository, IHttpContextAccessor httpContextAccessor, IStatusService statusService, ITaskHistoryService taskHistoryService, IUserService userService, INotificationService notificationService) : base(repository)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _statusService = statusService;
            _userService = userService;
            _taskHistoryService = taskHistoryService;
            this.notificationService = notificationService;
        }
        public async Task<Mission> AddMission(Mission mission, List<int> userIds, bool emailNotification)
        {
            var addedMission = _repository.Add(mission);

            if (userIds != null && userIds.Count > 0)
            {
                var users = _userService.GetAll(u => userIds.Contains(u.Id)).ToList();

                addedMission.Assignees = users;


                _repository.Update(addedMission);

                if (emailNotification)
                {
                    var emailTasks = new List<Task>();

                    foreach (var user in users)
                    {
                        emailTasks.Add(HelperMissionMail.SendMissionAssignedMailAsync(user.Email, mission.Title));
                        notificationService.NewNotificationMission(user.Id);
                    }

                    await Task.WhenAll(emailTasks);
                }
                foreach (var userId in userIds)
                {
                    TaskHistory taskHistory = new TaskHistory
                    {
                        TaskId = addedMission.Id,
                        Description = mission.Description,
                        UserId = userId,
                        // DateCreated = DateTime.Now          
                    };

                    // TaskHistory kaydını kaydedin
                    _taskHistoryService.Add(taskHistory);
                }
            }

            return addedMission;
        }




        public IQueryable<Mission> GetAll()
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);
            return _repository.GetAll().Include(x => x.Assignees).Where(x => x.Project.CustomerId == customerId).Select(x => new Mission
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Project = x.Project,
                Priority = x.Priority,
                Status = x.Status,
                Assignees = x.Assignees.ToList(),
                TaskHistory = x.TaskHistory.ToList(),
                Files = x.Files.ToList(),
                Comments = x.Comments.ToList(),
            });


        }


        public List<MissionDto> GetAllMission(int id)
        {

            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);

            return _repository.GetAll()
                .Include(x => x.Assignees)
                .Where(x => x.Project.CustomerId == customerId && x.ProjectId==id)
                .Select(x => new MissionDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    StatusId = x.StatusId,
                    Assignees = x.Assignees.ToList(),
                })
                .ToList();
        }

        public MissionGetByDto GetByMissionId(int missionId)
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
               TotalDuration= (TimeSpan)p.TotalDuration,
               IsActive = p.IsActive,
               IsCompleted = p.IsCompleted,
               Description = p.Description,
               StartDate = p.StartDate,
               EndDate = p.EndDate,
               MissionStartDate=p.MissionStartdate,
               EndTime=p.EndTime,
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

            return mission;
        }

        

        public UserCountDto GetCustomerInformationCounts(int userId)
        {
            var taskCount = _repository.GetAll()
                .Where(x => x.Project.CustomerId == userId).Count();

            return new UserCountDto
            {
                TaskCount = taskCount,
            };
        }

        public UserCountDto GetUserInformationCounts(int userId)
        {
            var taskCount = _repository.GetAll()
                                .Include(m => m.Assignees) 
                                .Where(m => m.Assignees.Any(a => a.Id == userId)) 
                                .Count();
            return new UserCountDto
            {
                TaskCount = taskCount
            };
        }

        public bool UpdateMissionDescription(int missionId, string description)
        {
            var mission = _repository.GetAll().FirstOrDefault(m => m.Id == missionId);
            if (mission != null)
            {
                mission.Description = description;
                _repository.Update(mission);
                return true;
            }
            return false;
        }
        public bool UpdateStatus(int missionId, int statusId)
        {
            
            var mission = _repository.GetAll().FirstOrDefault(m => m.Id == missionId);

            if (mission != null)
            {
                
                mission.StatusId = statusId;
                _repository.Update(mission);

                return true; 
            }

            return false; 
        }

        public TimeSpan GetMissionDuration(int missionId)
        {
            var mission = GetById(missionId);

            var totalDuration = mission.TotalDuration ?? TimeSpan.Zero;

            if (mission.IsActive && mission.StartDate != null)
            {
                DateTime now = DateTime.Now;
                TimeSpan currentDuration = now - mission.StartDate.Value;
                return totalDuration + currentDuration;
            }
            return totalDuration;
        }
        public bool StartMission(int missionId)
        {
            var mission = GetById(missionId);
            if (mission.MissionStartdate == null)
            {
                mission.MissionStartdate = DateTime.Now; 
            }
            if (mission.IsCompleted == true && mission.IsActive==true)
            {
                mission.StartDate = DateTime.Now;
                mission.IsActive = false;
                _repository.Update(mission);
            }
            
            return true;

        }
        public bool StopMission(int missionId)
        {
            var mission = GetById(missionId);

            UpdateTotalDuration(mission);
            mission.IsActive = true;
           _repository.Update(mission);
            return true;
        }

        public bool CompleteMission(int missionId)
        {
            var mission = GetById(missionId);
            UpdateTotalDuration(mission);
            mission.IsActive = true;
            mission.IsCompleted = false;  
            mission.EndTime = DateTime.Now; 
            _repository.Update(mission);
            return true;
        }

        private void UpdateTotalDuration(Mission mission)
        {
                DateTime now = DateTime.Now;
                TimeSpan elapsedTime = now - mission.StartDate.Value;
                mission.TotalDuration += elapsedTime;
                //mission.StartDate = null;
                _repository.Update(mission);
        }

        public MissionEfficiencyDto GetUserMissionEfficiency(int userId)
        {
            var userTasks = _repository.GetAll()
                              .Where(m => m.Assignees.Any(a => a.Id == userId))
                              .ToList();
            int completedTasks = userTasks.Count(m => m.IsCompleted);
            int totalTasks = userTasks.Count;
            TimeSpan plannedTime = TimeSpan.Zero;
            foreach (var task in userTasks)
            {
                if (task.EndDate.HasValue && task.MissionStartdate.HasValue)
                {
                    plannedTime += task.EndDate.Value - task.MissionStartdate.Value;
                }
            }
            TimeSpan actualTime = userTasks
                .Where(m => m.TotalDuration.HasValue)
                .Select(m => m.TotalDuration.Value)
                .Aggregate(TimeSpan.Zero, (total, next) => total.Add(next));
            double taskCompletionRate = totalTasks > 0
                ? (double)completedTasks / totalTasks * 100
                : 0;
            double timeEfficiency = actualTime.TotalMinutes > 0
                ? plannedTime.TotalMinutes / actualTime.TotalMinutes * 100
                : 0;
            var missionEfficiencyDto = new MissionEfficiencyDto
            {
                CompletedTasks = completedTasks,
                TotalTasks = totalTasks,
                PlannedTime = plannedTime,
                ActualTime = actualTime,
                TaskCompletionRate = taskCompletionRate,
                TimeEfficiency = timeEfficiency
            };
            return missionEfficiencyDto;
        }

        public List<MissionCompletionTimeDto> GetMissionCompletionTimes(int userId)
        {
            var userTasks = _repository.GetAll()
                   .Where(m => m.Assignees.Any(a => a.Id == userId))
                   .ToList();

            var taskCompletionTimes = new List<MissionCompletionTimeDto>();

            foreach (var task in userTasks)
            {
                // Planlanan süre (EndTime - StartDate)
                TimeSpan plannedDuration = TimeSpan.Zero;
                if (task.StartDate.HasValue && task.EndTime.HasValue)
                {
                    plannedDuration = task.EndTime.Value - task.StartDate.Value;
                }

                // Gerçekleşen süre (EndDate - StartDate)
                TimeSpan actualDuration = TimeSpan.Zero;
                if (task.StartDate.HasValue && task.EndDate.HasValue)
                {
                    actualDuration = task.EndDate.Value - task.StartDate.Value;
                }

                // Geç tamamlanma kontrolü
                bool isLate = task.EndDate.HasValue && task.EndDate > task.EndTime;

                // DTO'yu doldur
                var dto = new MissionCompletionTimeDto
                {
                    TaskTitle = task.Title,
                    PlannedDuration = plannedDuration,
                    ActualDuration = actualDuration,
                    IsLate = isLate
                };

                taskCompletionTimes.Add(dto);
            }

            return taskCompletionTimes;
        }

        public TimeSpan GetAverageCompletionTime(int userId)
        {
            var tasks = _repository.GetAll()
                  .Where(m => m.IsCompleted && m.Assignees.Any(a => a.Id == userId))
                  .ToList();

            if (tasks.Count == 0)
                return TimeSpan.Zero;

            TimeSpan totalTime = TimeSpan.Zero;

            foreach (var task in tasks)
            {
                if (task.StartDate.HasValue && task.EndDate.HasValue)
                {
                    totalTime += task.EndDate.Value - task.StartDate.Value;
                }
            }

            // Ortalama süreyi hesapla
            return TimeSpan.FromTicks(totalTime.Ticks / tasks.Count);
        }

        public List<TaskStatusDto> GetTaskStatusDistribution()
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);
            var users = _userService.GetAll()
        .Where(u => u.CustomerId == customerId && u.UserTypeId == 3) // Müşteri ile ilişkilendirilmiş kullanıcıları filtreliyoruz
        .ToList();
            var taskStatusDistributions = new List<TaskStatusDto>();

            foreach (var user in users)
            {
                var userTaskDistributions = _repository.GetAll().Include(m => m.Assignees)
                    .Where(m => m.Assignees.Any(a => a.Id == user.Id))
                    .ToList();

                var completedTasks = userTaskDistributions.Count(m => m.IsCompleted);
                var ongoingTasks = userTaskDistributions.Count(m => !m.IsCompleted && m.EndDate >= DateTime.Now);
                var delayedTasks = userTaskDistributions.Count(m => !m.IsCompleted && m.EndDate < DateTime.Now);

                var distributionDto = new TaskStatusDto
                {
                    Email = user.Email,
                    CompletedTasks = completedTasks,
                    OngoingTasks = ongoingTasks,
                    DelayedTasks = delayedTasks
                };

                taskStatusDistributions.Add(distributionDto);
            }
            return taskStatusDistributions;
        }
        public IEnumerable<Mission> GetAllMissionsByProjectId(int id)
        {
            return _repository.GetAll()
                .Where(m => m.ProjectId == id)
                .ToList();
        }
    }
}
