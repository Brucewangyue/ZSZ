using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.DTO;
//using Y.ZSZ.BLL;
using Y.ZSZ.IBLL;
namespace Y.ZSZ.ManageWeb.Controllers
{
    public class MainController : Controller
    {
        public ISettingBLL SettingBLL { get; set; }
        // GET: Main
        public ActionResult Index()
        {
            //long id= SettingBLL.ADD("company", "越飞公司","公司名称");
            Session["user"] = 123;
            return View();
        }

        public ActionResult GetSession()
        {
            string result = "没有Session";
            if (Session["user"]!=null)
            {
                result = "有Session";
            }
           
            return Content(result);
        }
    }
}