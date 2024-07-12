using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface ICustomerService : IService<Customer>
    {
        IQueryable<CustomerGetAllDto> GetAllWithUserCount();
        IQueryable<Customer> GetAll(Expression<Func<Customer, bool>> predicate);
        Customer GetById(int id);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        bool Delete(int id);
    }
}
