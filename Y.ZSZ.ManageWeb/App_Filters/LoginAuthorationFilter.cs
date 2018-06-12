using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc;
using Y.ZSZ.DTO.ResultDTO;

namespace Y.ZSZ.ManageWeb.App_Start
{
    public class LoginAuthorationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Count() > 0
                || filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Count() > 0)
            {
                return;
            }

            if (SessionManage.GetAadminUser(filterContext.HttpContext) == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())//ajax请求
                {
                    filterContext.Result = new JsonResult { ContentType = "application/json", Data = new AjaxResult { Msg = "登录过期,请重新登录", Status = "no" } };
                }//
                else
                {
                    filterContext.Result = new RedirectResult("~/Login/Index");
                }
            }

        }
    }
}