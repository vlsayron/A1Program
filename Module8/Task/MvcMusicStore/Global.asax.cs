using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcMusicStore.Controllers;
using MvcMusicStore.Infrastructure;
using NLog;
using PerformanceCounterHelper;

namespace MvcMusicStore
{
    public class MvcApplication : HttpApplication
    {

        private readonly ILogger _logger;
        public MvcApplication()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        protected void Application_Start()
        {
            _logger.Info("Start init application");

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.Register(f => LogManager.GetLogger("ForControllers")).As<ILogger>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Go to home"))
            {
                counterHelper.RawValue(Counters.GoToHome, 0);
            }
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Success Login"))
            {
                counterHelper.RawValue(Counters.SuccessLogIn, 0);
            }
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Success Log out"))
            {
                counterHelper.RawValue(Counters.SuccessLogOff, 0);
            }

            _logger.Info("The application is running");
        }
    }
}
