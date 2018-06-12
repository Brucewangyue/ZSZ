using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.ResultDTO;
using Y.ZSZ.IBLL;
using Y.ZSZ.ManageWeb.App_Start;
using Y.ZSZ.ManageWeb.Models;

namespace Y.ZSZ.ManageWeb.Controllers
{
    public class AdminUserController : Controller
    {
        public IAdminUserBLL adminUserBLL { get; set; }
        public ICityBLL cityBLL  { get; set; }
        public IRoleBLL roleBLL { get; set; }
        

        [Permission("admin.List")]
        public ActionResult Index()
        {
            List<AdminUserDTO> admins = adminUserBLL.GetModels();
            return View(admins);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.citys= cityBLL.GetALL();
            return View(roleBLL.GetAll());
        }

        [HttpPost]
        public ActionResult Add(AdminUserAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new AjaxResult() { Status = "no", Msg = ValidModelState.Valid(ModelState) });
            }

            if (model.Pwd!=model.ReCheckPwd)
            {
                throw new ArgumentException("两次密码不相同");
            }

            adminUserBLL.ADD(model.Name, model.PhoneNum, model.Pwd, model.Email, model.CityId,model.RoleIds);
            return Json(new AjaxResult());
        }
    }
}