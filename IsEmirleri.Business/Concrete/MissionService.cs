using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.MissionDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class MissionService : Service<Mission>, IMissionService
    {
        private readonly IRepository<Mission> _repository;

        public MissionService(IRepository<Mission> repository):base(repository)
        {
            _repository = repository;
        }

        public IQueryable<MissionGetAllDto> GetAllWithProjectName()
        {
            return _repository.GetAll().Include(x => x.Project).Include(x=>x.Priority).Select(x => new MissionGetAllDto
            {
              Id = x.Id,
              Title= x.Title,
              Description = x.Description,
              StartDate = x.StartDate, 
              EndDate = x.EndDate,
              ProjectName = x.Project.Name,
              PriorityName= x.Priority.Name

            });
        }

    }
}
