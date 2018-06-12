using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.DTO.ResultDTO;
using Y.ZSZ.IBLL;
using System.IO;
using CaptchaGen;
using Y.ZSZ.Core;
using Y.ZSZ.DTO;

namespace Y.ZSZ.ManageWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IAdminUserBLL adminUserBLL { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string phone, string pwd, string vcode)
        {
            if (vcode != (string)TempData["vcode"])
            {
                return Json(new AjaxResult { Status = "no", Msg = "验证码错误" });
            }

            AdminUserDTO admin = adminUserBLL.CheckUser(phone, pwd);
            if (admin != null)
            {
                Session["user"] = admin;
                return Json(new AjaxResult());
            }
            else
            {
                return Json(new AjaxResult { Msg="用户名或者密码错误",Status="no"});
            }

               
        }

        public ActionResult VerifyCode()
        {
            string vcode = CommomHelper.CreateVerifyCode(4);
            TempData["vcode"] = vcode;
            Stream stream = ImageFactory.GenerateImage(vcode, 60, 100, 20, 1);
            return File(stream, "image/jpeg");
        }
    }
}