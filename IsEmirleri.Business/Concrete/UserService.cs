using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class UserService : Service<AppUser>, IUserService
    {
        private readonly IRepository<AppUser> _repository;
        public UserService(IRepository<AppUser> repo):base(repo)
        {
            _repository = repo;
        }
        public AppUser CheckLogin(AppUser user)
        {
   
            return _repository.GetAll().Include(p => p.UserType).Where(p => p.Email == user.Email && p.Password == user.Password).FirstOrDefault();

        }
        public AppUser Add(AppUser user)
        {
            
           // user.UserTypeId = 3;
            return _repository.Add(user);
        }
        public IQueryable<AppUser> GetAll(int userId)
        {
            return _repository.GetAll(v => v.Id == userId).Select(x => new AppUser
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                UserType = x.UserType,
                Projects = x.Projects,
                Tasks = x.Tasks

            });
        }



    }
}
