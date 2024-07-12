using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.CustomerDTOs;
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
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository):base(repository)
        {
            _repository = repository;
        }
        public Customer Add(Customer Customer)
        {
            return _repository.Add(Customer);
        }

        public bool Delete(int id)
        {
            _repository.Delete(id);
            return true;
        }


        public IQueryable<CustomerGetAllDto> GetAllWithUserCount()
        {
            var result = _repository.GetAll().Select(c => new CustomerGetAllDto
            {
                Id = c.Id,
                Name = c.Name,
                UserLimit = c.UserLimit,
                UserCount = c.AppUsers.Count
            });
            return result;
        }
        public Customer GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            return _repository.GetAll().Where(predicate);
        }

        public Customer Update(Customer Customer)
        {
            return _repository.Update(Customer);
        }
    }
}
