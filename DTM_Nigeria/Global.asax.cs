using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DTM_Nigeria.Models;
using DTM_Nigeria.Validation;
using System.Globalization;
using System.Threading;

namespace DTM_Nigeria
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            //routes.Add("SOAP",
            //    new Route("soap", new WebServiceRouteHandler("Api/ExportLocationsToSiteAssessment.asmx")));





        }

        //public class WebServiceRouteHandler : IRouteHandler
        //{
        //    private string _VirtualPath;

        //    public WebServiceRouteHandler(string virtualPath)
        //    {
        //        _VirtualPath = virtualPath;
        //    }

        //    public IHttpHandler GetHttpHandler(RequestContext requestContext)
        //    {
        //        return new System.Web.Services.Protocols.WebServiceHandlerFactory().GetHandler(HttpContext.Current,
        //            "*",
        //            _VirtualPath,
        //            HttpContext.Current.Server.MapPath(_VirtualPath));
        //    }
        //}

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            //CultureInfo culture = new CultureInfo("en-GB");
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;

            //added on march 17th
           // DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredIfValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(ValidatableObjectAdapter));
        }
    }
}