using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETL.GenericCruder.Core;
using ETL.GenericCruder.MvcUI.Infrastructure;
using ETL.GenericCruder.MvcUI.Models;
using System.Web.Routing;
using System.Globalization;
using System.Data.Entity;
using System.Reflection;

namespace ETL.GenericCruder.MvcUI.Controllers
{
    [MustHasRouteValue("appName")]
    public class ApplicationHomeController : Controller
    {
        public ActionResult Index(string appName)
        {
            IEntityTypeManager typeManager = DependencyResolver.Current.GetService<IEntityTypeManager>();
            DbContext context = DependencyResolver.Current.GetService<DbContext>();
            IEnumerable<Type> typesInApp = typeManager.GetTypesInNamespace(appName);
            //var a = context.GetType().GetProperties().Select(pi => pi.PropertyType);
            //var b = a.Where(t => t.IsGenericType && t.GetGenericTypeDefinition()==typeof(DbSet<>));
            //var c = b.Select(t => t.GetGenericArguments().Single());
            IEnumerable<Type> typesInContext = context.GetType().GetProperties().Select(pi => pi.PropertyType)
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(DbSet<>)).Select(t => t.GetGenericArguments().Single());
            List<string> typeNames = typesInApp.Intersect(typesInContext).Select(t => t.Name).ToList();
            if (typeNames==null || !typeNames.Any())
            {
                Redirection redirection = Redirection.OpenRedirection(HttpContext, "ApplicationNotFound", "Error", new RouteValueDictionary() { { "appName", appName } });
                return redirection.GetResult();
            }
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            ApplicationDetailsVM details = new ApplicationDetailsVM
            {
                AppName = ti.ToTitleCase(appName),
                TypeNames = typeNames
            };
            return View(details);
        }
    }
}