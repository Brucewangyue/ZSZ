using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Y.ZSZ.CoreMvc;
using Y.ZSZ.ManageWeb.App_Start;

namespace Y.ZSZ.ManageWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //区域
            AreaRegistration.RegisterAllAreas();
            //路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //IOC
            AutofacConfig.RegisterAutofac();
            //过滤器
            Y.ZSZ.CoreMvc.App_Start.FiltersConfig.RegisterFilters(GlobalFilters.Filters);
            FiltersConfig.RegisterFilters(GlobalFilters.Filters);
            //日志
            log4net.Config.XmlConfigurator.Configure();
            //扩展模型适配器
            ModelBinderConfig.RegisterModelBinder(ModelBinders.Binders);
        }
    }
}
