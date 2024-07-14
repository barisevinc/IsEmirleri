using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.CustomerDTOs;
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
    public class CustomerService : Service<Customer>, ICustomerService
    {

        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository, IRepository<AppUser> appUserRepository) : base(repository)
        {
            _repository = repository;
            _appUserRepository = appUserRepository;
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
                UserCount = c.AppUsers.Where(i=>i.IsDeleted==false&&i.UserTypeId==3).Count()
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

        public CustomerGetAllDto UpdateCustomer(Customer Customer)
        {
            _repository.Update(Customer);

            return GetAllWithUserCount().FirstOrDefault(i => i.Id == Customer.Id);
        }

        public IQueryable<AppUser> GetAllUsersById(int customerId)
        {
            return _appUserRepository.GetAll(u => u.CustomerId == customerId && u.IsDeleted == false ).Select(x => new AppUser
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                UserType = x.UserType,
                Projects = x.Projects,
                CustomerId = x.CustomerId,
                Tasks = x.Tasks

            });
        }
    }
}
