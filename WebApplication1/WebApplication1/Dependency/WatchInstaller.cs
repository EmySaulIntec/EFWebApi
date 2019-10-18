using Bussiness.Services.Base;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MyDbTest.Repositories;
using System.Linq;
using System.Web.Http;

namespace WebApplication1.Dependency
{
    public class WatchInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                             .BasedOn<ApiController>()
                             .LifestyleTransient());


            //container.Register(
            //Classes.FromThisAssembly()
            //    .BasedOn(typeof(IRepository<>))
            //    .WithService
            //    .AllInterfaces());

            //container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());


            var assembly = typeof(IAppService).Assembly;

            var interfaceList = assembly.GetTypes().Where(e => e.IsInterface &&

                (e.GetInterfaces().Contains(typeof(IAppService))
                 || e.GetInterfaces().Any(d => d.Name == typeof(IRepository<,>).Name)
                 )
                ).ToList();
            
            foreach (var currentInterface in interfaceList)
            {

                var className = currentInterface.Name.Substring(1);

                var implementedClass = assembly.GetTypes().FirstOrDefault(e => e.Name == className);

                container.Register(Component.For(currentInterface).ImplementedBy(implementedClass));
            }


        }
    }

}