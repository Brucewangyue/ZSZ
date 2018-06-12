using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.ResultDTO;
using Y.ZSZ.IBLL;
using Y.ZSZ.ManageWeb.Models;

namespace Y.ZSZ.ManageWeb.Controllers
{
    public class RoleController : Controller
    {
        public IRoleBLL roleBLL { get; set; }
        public IPermissionBLL permissionBLL { get; set; }
        // GET: Role
        public ActionResult Index()
        {
            return View(roleBLL.GetAll());
        }
        //新增
        [HttpGet]
        public ActionResult Add()
        {
            return View(permissionBLL.GetAll());
        }
        //
        [HttpPost]
        public ActionResult Add(RoleModel role)
        {
            roleBLL.Add(role.Name, role.Description, role.PermissionIds);
            return Json(new AjaxResult()); /*new NewtonJson(new AjaxResult());*/
        }

        public ActionResult Delete(long Id)
        {
            roleBLL.Delete(Id);
            return new NewtonJson(new AjaxResult());
        }
        [HttpGet]
        public ActionResult Update(long Id)
        {
            RoleDTO role = roleBLL.GetById(Id);
            List<PermissionDTO> permissions = permissionBLL.GetAll();
            RoleUpdateModel model = new RoleUpdateModel { Role = role, Permissions = permissions };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(RoleModel role,long id)
        {
            roleBLL.Update(id, role.Name, role.Description, role.PermissionIds);
            return Json(new AjaxResult());
        }

        public ActionResult BatchDelete(long[] selectRoleIds)
        {
            roleBLL.DeleteMany(selectRoleIds);
            return Json(new AjaxResult());
        }
    }
}