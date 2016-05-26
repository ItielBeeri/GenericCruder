using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ETL.GenericCruder.Core;
using ETL.GenericCruder.MvcUI.Infrastructure;
using System.Diagnostics;

namespace ETL.GenericCruder.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoggingConfig.RegisterLoggers(this);
            DIConfig.RegisterDependencies(this);
            UserEntitiesConfig.RegisterUserEntities(DependencyResolver.Current.GetService<IEntityTypeManager>());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(DependencyResolver.Current.GetService<CruderControllerFactory>());

            //this.BeginRequest += (s, e) => {
            //    Trace.WriteLine(DateTime.Now + ": In BeginRequst event with method " + this.Context.Request.HttpMethod);    
            //    HttpResponseBase response = new HttpResponseWrapper(HttpContext.Current.Response);
            //    response.WriteCorsHeaders();
            //    response.Flush();                
            //};
        }

        //protected void Application_BeginRequest(object sender, EventArgs args)
        //{
        //    Trace.WriteLine(DateTime.Now + ": In BeginRequst event with method " + this.Context.Request.HttpMethod);
        //    if (this.Context.Request.HttpMethod == "OPTIONS")
        //    {
        //        HttpResponseBase response = new HttpResponseWrapper(HttpContext.Current.Response);
        //        response.WriteCorsHeaders();
        //        response.End();
        //    }
        //}
    }
}
