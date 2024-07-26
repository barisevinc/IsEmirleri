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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business
{
    public static class BusinessExtansion
    {

        public static void AddBusinessDI_Dinamik(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes()
                                .Where(t => t.Namespace != null && t.Namespace.StartsWith("IsEmirleri.Business.Concrete") &&
                                            !t.Name.Contains('<') && !t.Name.Contains(">") && !t.Name.Contains("__"))
                                .ToArray();

            // Servisleri tarayın ve uygun olanları ekleyin
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (@interface.Name == $"I{type.Name}") // Interface'in sınıfın ismiyle uyumlu olup olmadığını kontrol edin
                    {
                        services.AddScoped(@interface, type);
                    }
                }
            }
        }

        public static void AddBusinessDI(this IServiceCollection services)
        {
            services.AddScoped(typeof (IService<> ), typeof (Service<>));
           



        }
        public static void AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
        }
    }
}
