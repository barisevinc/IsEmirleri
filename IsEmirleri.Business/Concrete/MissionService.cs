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
        

        public MissionService(IRepository<Mission> repository, IHttpContextAccessor httpContextAccessor) :base(repository)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable<Mission> GetAll()
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value);
            var item2= base.GetAll()
                .Include(x => x.Assignees)
                .Include(x=>x.Status)
                .Include(x=>x.Priority)
                .Include(x=>x.Project)
                .Include(x=>x.TaskHistory)
                .Include(x=>x.Comments)
                .Include(x=>x.Files)               
                .Where(x => x.Project.CustomerId == customerId).AsEnumerable().AsQueryable();

            var item= _repository.GetAll().Include(x=>x.Assignees).Where(x => x.Project.CustomerId == customerId).AsEnumerable().Select(x => new Mission
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

                

            }).AsQueryable();
            return item2;

        }

        public IQueryable<MissionDto> GetAllMissionDto()
        {
            return _repository.GetAll().Include(s => s.Status).Select(x => new MissionDto
            {

                Id = x.Id,
                Title = x.Title,
                MissionStatus = x.Status
            });

        }
    }
}
