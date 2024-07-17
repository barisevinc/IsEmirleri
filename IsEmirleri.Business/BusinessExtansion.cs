using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Concrete;
using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Repository.Shared.Abstract;
using IsEmirleri.Repository.Shared.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business
{
    public static class BusinessExtansion
    {
        public static void AddBusinessDI(this IServiceCollection services)
        {
            services.AddScoped(typeof (IService<> ), typeof (Service<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IMissionService, MissionService>();
            services.AddScoped<IPriorityService, PriorityService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskFileService, TaskFileService>();
            services.AddScoped<ITaskHistoryService, TaskHistoryService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ICommentFileService, CommentFileService>();
            services.AddScoped<IUserTypeService, UserTypeService>();

        }
        public static void AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
        }
    }
}
