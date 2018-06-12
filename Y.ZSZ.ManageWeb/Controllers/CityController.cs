using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.DTO.ResultDTO;
using Y.ZSZ.IBLL;

namespace Y.ZSZ.ManageWeb.Controllers
{
    public class CityController : Controller
    {
        public ICityBLL cityBLL { get; set; }
        // GET: City
        public ActionResult Index()
        {
            return View(cityBLL.GetALL());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            cityBLL.ADD(name);
            return Json(new AjaxResult());
        }
    }
}