using AutoMapper;
using mono_lvl2.Service;
using mono_lvl2.Service.ViewModels;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mono_lvl2.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(configuration => {
                configuration.CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();
                configuration.CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();
            });
        }
    }
}
