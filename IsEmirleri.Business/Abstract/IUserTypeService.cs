﻿using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IUserTypeService:IService<AppUserType>
    {
        IQueryable<AppUserType> GetAllType();
    }
}
