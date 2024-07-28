using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.MissionStatusDTOs;
using IsEmirleri.DTO.PriorityDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class PriorityService : Service<Priority>, IPriorityService
    {
        private readonly IRepository<Priority> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Mission> _repositoryMission;

        public PriorityService(IRepository<Priority> repository, IHttpContextAccessor httpContextAccessor, IRepository<Mission> repositoryMission) : base(repository)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _repositoryMission = repositoryMission;
        }

        public Priority Add(Priority priority)
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            priority.CustomerId = customerId;
            return _repository.Add(priority);
        }

        public bool Delete(int id)
        {
            _repository.Delete(id);
            return true;
        }

        public IQueryable<Priority> GetAll(Expression<Func<Priority, bool>> predicate)
        {
            return _repository.GetAll().Where(predicate);
        }

        public IQueryable<PriorityGetAllDto> GetAllWithTaskCount()
        {
            var customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            var result = _repository.GetAll().Where(x=>x.CustomerId==customerId).Select(p => new PriorityGetAllDto
            {
                Id = p.Id,
                Name = p.Name,
                TaskCount = _repositoryMission.GetAll().Where(x => x.PriorityId == p.Id).Count()
            }); 
            return result;
        }
        public Priority GetById(int id)
        {
            return _repository.GetById(id);
        }

       public  Priority UpdatePriority(Priority priority)
        {
          return _repository.Update(priority);
          
        }
    }
}

