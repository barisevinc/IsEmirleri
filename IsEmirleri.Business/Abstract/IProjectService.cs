using IsEmirleri.Business.Shared.Abstract;
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
        
        IQueryable<ProjectGetAllDto> GetAllWithUsers();       

        IQueryable<AppUser> FillUsers();
     
        Project AddProject(Project project, List<string> userIds);

        bool Delete(int id);

        ProjectUpdateDto UpdateProject(ProjectUpdateDto updateDto);

     

       


    }
}
