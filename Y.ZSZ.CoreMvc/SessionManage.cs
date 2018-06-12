using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Y.ZSZ.DTO;

namespace Y.ZSZ.CoreMvc
{
    public class SessionManage
    {
        public static AdminUserDTO GetAadminUser(HttpContextBase context)
        {
            return context.Session["user"] != null ? context.Session["user"] as AdminUserDTO : null;
        }
    }
}
