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
        private readonly IHttpContextAccessor _httpContextAccessor;



        public UserService(IRepository<AppUser> repo, IHttpContextAccessor httpContextAccessor) : base(repo)
        {
            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }
        public AppUser CheckLogin(AppUser user)
        {
   
            return _repository.GetAll().Include(p => p.UserType).Where(p => p.Email == user.Email && p.Password == user.Password).FirstOrDefault();

        }
        public AppUser Add(AppUser user)
        {
           var userId= int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var appUser = _repository.GetFirstOrDefault(i => i.Id == userId);
            user.CustomerId = appUser.CustomerId;
            user.UserTypeId = 3;
           
            return _repository.Add(user);
        }
        public IQueryable<AppUser> GetAll()
        {
            var id = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var appUser = _repository.GetFirstOrDefault(i => i.Id == id);

            return _repository.GetAll(u => u.CustomerId == appUser.CustomerId && u.IsDeleted==false&& u.UserTypeId==3).Select(x => new AppUser
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
