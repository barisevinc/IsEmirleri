using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.MissionStatusDTOs;
using IsEmirleri.DTO.PriorityDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class PriorityService : Service<Priority>, IPriorityService
    {
        private readonly IRepository<Priority> _repository;

        public PriorityService(IRepository<Priority> repository) : base(repository)
        {
            _repository = repository;
        }

        public Priority Add(Priority priority)
        {
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
            var result = _repository.GetAll().Select(p => new PriorityGetAllDto
            {
                Id = p.Id,
                Name = p.Name,
                TaskCount = _repository.GetAll().Where(p => p.IsDeleted == false).Count()
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

