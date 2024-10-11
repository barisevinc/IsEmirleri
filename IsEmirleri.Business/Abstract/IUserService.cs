using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.UserDTOs;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IUserService:IService<AppUser>
    {
       
        IQueryable<UserCountDto> GetAll();
        AppUser CheckLogin(AppUser user);
        AppUser? Add(AppUser user);

        AppUser? AddCustomerUser(AppUser user);

        AppUser Profile();
        Task<Response<AppUser>> UpdateWithPhoto(AppUser user);
       Task<bool> NewUserPassword(string mail);
    

    }
}
