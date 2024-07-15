using IsEmirleri.Business.Shared.Abstract;
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
        
        //Projeleri listelerken projeye tanımlanmış kullanıcıları da getirmek için 
        IQueryable<ProjectGetAllDto> GetAllWithUsers();

        //Proje eklerken açılan select2 pencerindeki dropdown'a userları getirmek için
        IQueryable<AppUser> FillUsers();

        //IQueryable<Project> AddProject(Project project, List<int> userIds)

        IQueryable<Project> AddProject(Project project, List<string> userIds);

        bool Delete(int id);


        //Project Update(Project project);



    }
}
