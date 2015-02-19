using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Serilog;
using Serilog.Debugging;
using Serilog.Enrichers;
using Serilog.Extras.Web;
using Serilog.Extras.Web.Enrichers;

namespace HangFire_Playground
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureLogger();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureLogger()
        {

            SelfLog.Out = Console.Error;
            ApplicationLifecycleModule.DebugLogPostedFormData = true;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<HttpRequestRawUrlEnricher>()
                .Enrich.With(new ThreadIdEnricher(),
                    new MachineNameEnricher(),
                    new UserNameEnricher())
                .WriteTo.Trace(
                    outputTemplate: "{Timestamp} [{Level}] ({HttpRequestId}|{UserName}) {Message}{NewLine}{Exception}")
                .CreateLogger();

        }
    }
}
