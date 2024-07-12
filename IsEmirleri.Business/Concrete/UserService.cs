using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class UserService : Service<AppUser>, IUserService
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IRepository<Customer> _customerRepository; 
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IRepository<AppUser> repo, IRepository<Customer> customerRepo, IHttpContextAccessor httpContextAccessor) : base(repo)
        {
            _repository = repo;
            _customerRepository = customerRepo; 
            _httpContextAccessor = httpContextAccessor;
        }

        public AppUser CheckLogin(AppUser user)
        {
            return _repository.GetAll().Include(p => p.UserType).Where(p => p.Email == user.Email && p.Password == user.Password).FirstOrDefault();
        }

        public AppUser Add(AppUser user)
        {
            //int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            var customer = _customerRepository.GetById(user.CustomerId.Value);
           
            //limit kontrol usertype vermezsek admin dahil limit tutuyor
            int userCount = _repository.GetAll(u => u.CustomerId == customer.Id && !u.IsDeleted &&u.UserTypeId==3).Count();

            if (userCount >= customer.UserLimit)
            {
                return null;
            }

            user.CustomerId = customer.Id;
            user.UserTypeId = 3;
            _repository.Add(user);
            return user;
        }
        public IQueryable<AppUser> GetAll()
        {
           

            return _repository.GetAll(u => u.CustomerId == int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value) && u.IsDeleted==false&& u.UserTypeId==3).Select(x => new AppUser
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                UserType = x.UserType,
                Projects = x.Projects,
                CustomerId=x.CustomerId,
                Tasks = x.Tasks

            });
        }



    }
}
