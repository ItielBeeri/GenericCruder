using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ETL.GenericCruder.Core;
using ETL.GenericCruder.MvcUI.Controllers;
using System.Diagnostics;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public class CruderControllerFactory :DefaultControllerFactory
    {
        IEntityTypeManager _userEntitiesManager;
        public CruderControllerFactory(IEntityTypeManager userEntitiesManager)
        {
            _userEntitiesManager = userEntitiesManager;
        }

        private void SetAction(RequestContext requestContext, string actionName)
        {
            requestContext.RouteData.Values["action"] = actionName;
        }

        private void SetController(RequestContext requestContext, string controllerName)
        {
            requestContext.RouteData.Values["controller"] = controllerName;
        }

        private IController CreateRedirectionController(RequestContext requestContext, string actionNameToRedirectTo, string controllerNameToRedirectTo, RouteValueDictionary routeValues)
        {
            Redirection.OpenRedirection( requestContext.HttpContext, actionNameToRedirectTo, controllerNameToRedirectTo, routeValues);
            SetAction(requestContext, "ByRedirectionManager");
            return new RedirController();
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Trace.WriteLine(DateTime.Now + ": CruderControllerFactory receive request with method " + requestContext.HttpContext.Request.HttpMethod);
            
            if (controllerName=="Cruder")
            {
                //if (requestContext.HttpContext.Request.HttpMethod == "OPTIONS")
                //{
                //    requestContext.HttpContext.Response.WriteCorsHeaders();
                //    requestContext.HttpContext.Response.Flush();
                //    return null;
                //}
                RouteValueDictionary routeValues = requestContext.RouteData.Values;
                string appName = (string)routeValues["appName"], entityTypeName = (string)routeValues["entityType"];
                string entityName = string.Join(".", appName, entityTypeName);
                Type entityType = _userEntitiesManager.GetRegistratedType(entityName);
                if (entityType==null)
                {
                    return CreateRedirectionController(requestContext, "EntityTypeNotFound", "Error", routeValues);
                }
                if (!requestContext.HttpContext.Request.IsAjaxRequest())
                {
                    SetController(requestContext, "CrudHtmlUi");
                    SetAction(requestContext, "Index");
                    return new CrudHtmlUiController();
                }
                Type controllerType = typeof(CruderController<>).MakeGenericType(entityType);
                IController controller = (IController)DependencyResolver.Current.GetService(controllerType);
                return controller;
            }
            if (_userEntitiesManager.GetRegistratedNamespaces().Any(ns=>TypeNameCompareHelper.IsStringMatchesTypeName(controllerName, ns)))
            {
                requestContext.RouteData.Values["appName"] = controllerName;
                SetController(requestContext, "ApplicationHome");
                SetAction(requestContext, "Index");
                return new ApplicationHomeController();
            }
            return base.CreateController(requestContext, controllerName);
        }
    }
}