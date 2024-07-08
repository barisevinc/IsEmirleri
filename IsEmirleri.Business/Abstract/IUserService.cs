﻿using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Models;
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
       
        IQueryable<AppUser> GetAll(int userId);
        AppUser CheckLogin(AppUser user);

    }
}