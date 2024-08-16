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
            var users = _appUserRepository.GetAll().Where(u => u.CustomerId == id).ToList();
            foreach (var item in users)
            {
                item.IsDeleted = true;
                _appUserRepository.Update(item);
            }
            var customer = _repository.GetById(id);
            if (customer == null)
            {
                return false; 
            }
            customer.IsDeleted = true;
            _repository.Update(customer);

            return true;

        }


        public IQueryable<CustomerGetAllDto> GetAllWithUserCount()
        {
            var result = _repository.GetAllWithIsDeleted().OrderBy(u => u.IsDeleted).Select(c => new CustomerGetAllDto
            {
                Id = c.Id,
                Name = c.Name,
                UserLimit = c.UserLimit,
                IsDeleted = c.IsDeleted,
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
            return _appUserRepository.GetAllWithIsDeleted(u => u.CustomerId == customerId).OrderBy(u => u.IsDeleted).Select(x => new AppUser
            {
                Id = x.Id,
                Email = x.Email,
                Picture = x.Picture,
                Password = x.Password,
                UserType = x.UserType,
                UserTypeId = x.UserTypeId,               
                CustomerId = x.CustomerId,
                IsDeleted = x.IsDeleted,
                Tasks = x.Tasks

            });
        }
        public bool IsLimitAvailable(int customerId)
        {
            var customer = _repository.GetById(customerId);

            int userCount = _appUserRepository.GetAll(u => u.CustomerId == customer.Id && u.UserTypeId == 3).Count();
            if (userCount >= customer.UserLimit)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public bool UpdateCustomerUsers(AppUser user)
        {
            var appUser = _appUserRepository.GetById(user.Id);
            if (IsLimitAvailable(appUser.CustomerId.Value))
            {
                appUser.Email = user.Email;
                appUser.Password = user.Password;
                appUser.IsDeleted = user.IsDeleted;
                appUser.UserTypeId = user.UserTypeId;
                _appUserRepository.Update(appUser);
                return true;
            }
            else if(user.IsDeleted)
            {
                appUser.UserTypeId=user.UserTypeId;
                appUser.IsDeleted= true;
                appUser.Email = user.Email;
                appUser.Password = user.Password;
                _appUserRepository.Update(appUser);
                return false;
                
            }
            _appUserRepository.Update(appUser);
            return true;
            
        }
    }
}
