using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class MissionService : Service<Mission>, IMission
    {
        private readonly IRepository<Mission> _repository;

        public MissionService(IRepository<Mission> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
