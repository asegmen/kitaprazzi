using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Core.Repository;


namespace Zathura.Admin.Helper
{
    public class BootStrapper
    {
        //runs on boot period
        public static void RunConfig()
        {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ContentRepository>().As<IContentRepository>();
            builder.RegisterType<MediaItemRepository>().As<IMediaItemRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<SystemSettingRepository>().As<ISystemSettingRepository>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();
            builder.RegisterType<MainSliderRepository>().As<IMainSliderRepository>();
            builder.RegisterType<MainControlRepository>().As<IMainControlRepository>();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>();
            builder.RegisterType<DealerRepository>().As<IDealerRepository>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}