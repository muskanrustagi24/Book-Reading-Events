using Autofac;
using Autofac.Integration.Mvc;
using BookReadingEvents.DataAccess;
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
            
            builder.RegisterType<UserDataAccess>().As<IUserDataAccess>().InstancePerRequest();
            builder.RegisterType<EventDataAccess>().As<IEventDataAccess>().InstancePerRequest();
            //builder.RegisterType<BookReadingEventsDbContext>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}