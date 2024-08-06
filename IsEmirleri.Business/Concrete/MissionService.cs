using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
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

namespace IsEmirleri.Business.Concrete
{
    public class MissionService : Service<Mission>, IMissionService
    {
        private readonly IRepository<Mission> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStatusService _statusService;

        public MissionService(IRepository<Mission> repository):base(repository)
        {
            _repository = repository;
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

       
    }
}
