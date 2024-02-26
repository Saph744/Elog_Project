using eLog.Domain.Configuration;
using eLog.Domain.Service;
using eLog.Repository;
using eLog.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eLog.IOC
{
    public class ConfigureDependency
    {
        public static void RegisterDependencies(IServiceCollection services, IConnectionSetting connectionSetting)
        {
            // Registers all the Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDapperRepository, DapperRepository>();
            
            // service interfaces must inherit from IService to work
            Assembly ass = typeof(ICompanyService).GetTypeInfo().Assembly;
            // get all concrete types which implements IService in Quantum.Service Project
            var allServices = ass.GetTypes().Where(t =>
                t.GetTypeInfo().IsClass &&
                !t.GetTypeInfo().IsAbstract &&
                typeof(IService).IsAssignableFrom(t));

            foreach (var type in allServices)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Except
                        (allInterfaces.SelectMany(t => t.GetInterfaces()));
                foreach (var itype in mainInterfaces)
                {
                    if (allServices.Any(x => !x.Equals(type) && itype.IsAssignableFrom(x)))
                    {
                        throw new Exception("The " + itype.Name + " type has more than one implementations, please change your filter");
                    }
                    services.AddScoped(itype, type);
                }
            }
        }
    }

}
