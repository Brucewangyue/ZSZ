using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Y.ZSZ.ManageWeb.App_Start
{
    public class FiltersConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LoginAuthorationFilter());
            filters.Add(new PermissionAuthorizationFilter());
        }
    }
}