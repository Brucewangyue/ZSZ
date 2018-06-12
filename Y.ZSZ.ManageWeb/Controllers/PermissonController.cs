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
    public class PermissonController : Controller
    {
        public IPermissionBLL bll { get; set; }
        // GET: Permisson
        public ActionResult Index()
        {
            List<PermissionDTO> list = bll.GetAll();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string name,string description)
        {
            bll.Add(name, description);
            return new NewtonJson(new AjaxResult());
            //return RedirectToAction(nameof(Add));
        }

        public ActionResult Delete(long id)
        {
            bll.Delete(id);
            return new NewtonJson(new AjaxResult());
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            PermissionDTO dto= bll.GetById(id);
            return View(dto);
        }
        [HttpPost]
       // PermissionModel
        public ActionResult Update(PermissionModel model)
        {
            bll.Update(model.Id, model.Name, model.Description);
            return new NewtonJson(new AjaxResult());
        }
    }
}