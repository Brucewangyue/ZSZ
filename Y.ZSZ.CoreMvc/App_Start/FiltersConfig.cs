using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc.Filters;

namespace Y.ZSZ.CoreMvc.App_Start
{
    public class FiltersConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            //newton.json
            filters.Add(new JsonResultFilter());
           
        }
    }
}
