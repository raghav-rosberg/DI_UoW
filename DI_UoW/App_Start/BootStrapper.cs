using System.Reflection;
using LightInject;
using DI_UoW.Data.Infrastructure;
using DI_UoW.Data.UnitOfWork;
using DI_UoW.Service.UserService;
using DI_UoW.Mappings;
using DI_UoW.Data.UnitOfWork;

namespace DI_UoW
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetLightInjectContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetLightInjectContainer()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.Register<IUnitOfWork, UnitOfWork>(new PerScopeLifetime());
            container.Register(typeof(RepositoryBase<>), typeof(IRepository<>));
            container.Register<IUserService, UserService>(new PerScopeLifetime());
            container.EnableMvc();
        }
    }
}