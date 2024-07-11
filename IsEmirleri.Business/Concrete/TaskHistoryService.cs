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
    public class TaskHistoryService : Service<TaskHistory>, ITaskHistory
    {
        private readonly IRepository<TaskHistory> _repository;

        public TaskHistoryService(IRepository<TaskHistory> repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
