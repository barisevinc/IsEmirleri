using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using IsEmirleri.Repository.Shared.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class StatusService : Service<MissionStatus>, IStatusService
    {
        private readonly IRepository<MissionStatus> _repository;

        public StatusService(IRepository<MissionStatus> repo) : base(repo)
        {
            _repository = repo;
        }

        public IQueryable<MissionStatus> GetAllStatus()
        {
            return _repository.GetAll();
        }




        public MissionStatus Add(MissionStatus status)
        {

            return _repository.Add(status);
        }
        public IQueryable<MissionStatus> GetAll(int statusId)
        {
            return _repository.GetAll().Select(x => new MissionStatus
            {
                Id = x.Id,
                Name = x.Name,
                CustomerId = x.CustomerId,
            });
        }






    }
}
