using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.ResultDTO;
using Y.ZSZ.IBLL;

namespace Y.ZSZ.ManageWeb.App_Start
{
    public class PermissionAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //检测是否可以不检测
            //if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Count() != 0
            //    || filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Count() != 0)
            //{
            //    return;
            //}

            //获取所有权限
            PermissionAttribute[] permissions = (PermissionAttribute[])filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermissionAttribute), false);
            if (permissions.Count() == 0)
            {
                return;
            }

            //if (!(filterContext.HttpContext.Session["user"] is AdminUserDTO admin))
            //{
            //    if (filterContext.HttpContext.Request.IsAjaxRequest())
            //    {
            //        filterContext.Result = new JsonResult() { Data = new AjaxResult { Status = "no", Msg = "用户未登录" } };
            //    }
            //    else
            //    {
            //        filterContext.Result = new RedirectResult("~/Login/Index"); //new ContentResult { Content = "用户没有登录！" };
            //    }

            //    return;
            //}
            AdminUserDTO admin = SessionManage.GetAadminUser(filterContext.HttpContext);

            IAdminUserBLL adminUserBLL = DependencyResolver.Current.GetService<IAdminUserBLL>();

            foreach (PermissionAttribute permiision in permissions)
            {
                if (!adminUserBLL.HasPermission(admin.Id, permiision.PermissionName))
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult() { Data = new AjaxResult { Status = "no", Msg = "没有该访问权限" } };
                    }
                    else
                    {
                        ViewResult view= new ViewResult();
                        view.ViewName = "Error";
                        view.ViewBag.ErrorMsg = "非法访问";
                        filterContext.Result = view; //new ContentResult { Content = "" };
                    }

                    return;
                }
            }

        }
    }

    public class PermissionAttribute : Attribute
    {
        public string PermissionName { get; set; }

        public PermissionAttribute(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}