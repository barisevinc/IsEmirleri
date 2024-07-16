using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.PriorityDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IPriorityService:IService<Priority>
    {
        IQueryable<PriorityGetAllDto> GetAllWithTaskCount();
        IQueryable<Priority> GetAll(Expression<Func<Priority, bool>>predicate);
        Priority GetById(int id);
        Priority Add (Priority priority);
        Priority UpdatePriority (Priority priority);
        bool Delete (int id);
    }
}
