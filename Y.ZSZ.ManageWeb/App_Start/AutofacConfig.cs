using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Y.ZSZ.IBLL;
using System.Web.Mvc;

namespace Y.ZSZ.ManageWeb.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            //注册控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly).Where(type=>!type.IsAbstract).PropertiesAutowired();
            //注册业务逻辑层
            builder.RegisterAssemblyTypes(Assembly.Load("Y.ZSZ.BLL"))
                .Where(type => !type.IsAbstract && typeof(IAutofacBLL).IsAssignableFrom(type))
                .AsImplementedInterfaces().PropertiesAutowired();//.SingleInstance();//
            var container= builder.Build();
            //改变控制器的创建权，交由Autofac代理创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}