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
    public class TaskFileService : Service<TaskFile>, ITaskFileService
    {
        private readonly IRepository<TaskFile> _repository;

        public TaskFileService(IRepository<TaskFile> repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
