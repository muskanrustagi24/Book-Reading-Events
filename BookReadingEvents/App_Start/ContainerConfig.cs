using Autofac;
using Autofac.Integration.Mvc;
using BookReadingEvents.DataAccess.Services;
using System.Web.Mvc;

namespace BookReadingEvents
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterType<DummyUserData>().As<IUserData>().InstancePerRequest();
            builder.RegisterType<DummyEventData>().As<IEventData>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}