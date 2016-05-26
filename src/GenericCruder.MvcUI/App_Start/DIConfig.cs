using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using ETL.GenericCruder.Core;
using ETL.GenericCruder.Repository;
using System.Data.Entity;
using ETL.GenericCruder.Data;

namespace ETL.GenericCruder.MvcUI
{
    public class DIConfig
    {
        public const string ContainerKeyInApplication = "DIContainer";

        public static void RegisterDependencies(HttpApplication app)
        {
            Container container = new Container();
            WebRequestLifestyle perWebRequest = new WebRequestLifestyle();
            container.Register<IEntityTypeManager, UserEntitiesManager>(Lifestyle.Singleton);
            container.RegisterOpenGeneric(typeof(IRepository<>), typeof(GenericRepository<>), perWebRequest);
            container.Register<DbContext, UserEntitiesContext>(perWebRequest);
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            app.Application[ContainerKeyInApplication] = container;

        }

        public static Container Container
        {
            get { return (Container)HttpContext.Current.Application[ContainerKeyInApplication]; }
        }
    }
}