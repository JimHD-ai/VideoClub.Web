using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;


namespace VideoClub.Web.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MovieService>()
                .As<IMovieService>()
                .InstancePerRequest();
            builder.RegisterType<MovieRentServices>()
                .As<IMovieRentService>()
                .InstancePerRequest();
            builder.RegisterType<MovieCopyService>()
                .As<IMovieCopyService>()
                .InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>()
                .As<ApplicationDbContext>()
                .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}