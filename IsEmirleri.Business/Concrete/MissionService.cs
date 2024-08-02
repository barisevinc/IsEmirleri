using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStatusService _statusService;

        public MissionService(IRepository<Mission> repository, IHttpContextAccessor httpContextAccessor, IStatusService statusService) : base(repository)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _statusService = statusService;
        }

        public IQueryable<Mission> GetAll()
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);
            return _repository.GetAll().Include(x=>x.Assignees).Where(x => x.Project.CustomerId == customerId).Select(x => new Mission
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Project = x.Project,
                Priority = x.Priority,
                Status = x.Status,
                Assignees =x.Assignees.ToList(),
                TaskHistory=x.TaskHistory.ToList(),
                Files=x.Files.ToList(),
                Comments =x.Comments.ToList(),
            });
           

        }

        public List<MissionDto> GetAllMission()
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);

            return _repository.GetAll()
                .Include(x => x.Assignees)
                .Where(x => x.Project.CustomerId == customerId)
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



    }
}
