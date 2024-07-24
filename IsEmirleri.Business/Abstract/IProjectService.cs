﻿using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.ProjectDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IProjectService:IService<Project>
    {
        //her admin sadece bağlı olduğu firmanın proje listesini görebilsin
        IQueryable<ProjectGetAllDto> GetAllByCustomerId();

        //IQueryable<Project> GetAllByCustomerId();

        //select2 ddl'yi ilgili userlar ile doldurma
        IQueryable<AppUser> FillUsers();
     
        Project AddProject(Project project, List<string> userIds);

        bool Delete(int id);

        Project Update(Project project, int[] userIds);

        ProjectGetAllDto GetByProjectId(int id);






    }
}
