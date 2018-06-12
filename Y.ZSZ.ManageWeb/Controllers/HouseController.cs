using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.OptionDTO;
using Y.ZSZ.DTO.ResultDTO;
using Y.ZSZ.IBLL;
using Y.ZSZ.ManageWeb.Models;
using System.IO;
using Y.ZSZ.Core;
using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Filters.Watermarks;
using System.Text;

namespace Y.ZSZ.ManageWeb.Controllers
{
    [AllowAnonymous]
    public class HouseController : Controller
    {
        public IRegionBLL regionBLL { get; set; }
        public IHouseBLL houseBll { get; set; }
        public IDictionaryBLL dictionaryBLL { get; set; }
        public ICommunityBLL communityBLL { get; set; }
        // GET: House
        public ActionResult Index()
        {
            int dataCount = 0;
            List<HouseDTO> houses = houseBll.GetPageData(1, 20, out dataCount);
            ViewBag.Count = dataCount;
            return View(houses);
        }
        [HttpGet]
        public ActionResult Add()
        {
            AdminUserDTO adminUserDTO = SessionManage.GetAadminUser(this.HttpContext);
            HouseAddShowModel model = new HouseAddShowModel();
            model.RegionDTOs = regionBLL.GetByCityId((long)adminUserDTO.CityId);
            model.DictionaryDTOs = dictionaryBLL.GetByTypes("decoration", "status", "houseType", "type");
            if (model.RegionDTOs.Count > 0)
            {
                model.CommunityDTOs = communityBLL.GetByRegionId(model.RegionDTOs[0].Id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(HouseAddOptions model)
        {
            houseBll.Add(model);
            return Json(new AjaxResult());
        }
        [HttpGet]
        public ActionResult AddPicture(long houseId)
        {
            ViewBag.houseId = houseId;
            return View();
        }

        public ActionResult PictureShow(long houseId)
        {
            return View(houseBll.GetHousePics(houseId));
        }


        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase file,long houseId)
        {
            if (file==null)
            {
               return Json(new AjaxResult() { Status="no", Msg="没有选择文件"});
            }

            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension.ToLower()!=".jpeg" && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".gif" &&
                fileExtension.ToLower() != ".png")
            {
                return Json(new AjaxResult() { Status = "no", Msg = "图片格式有误" });
            }


            //文件名称
            file.InputStream.Position = 0;//指针复位
            string fileName = CommomHelper.CalcMD5(file.InputStream)+fileExtension;
            string dirPath = "/images/UploadPic/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/"+ fileName;
            string thumPath = "/images/UploadPic/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/thum_"+ fileName;
            string fullPath = HttpContext.Server.MapPath(dirPath);
            new FileInfo(fullPath).Directory.Create();
           

            houseBll.AddHousePic(houseId, dirPath, thumPath);

            //缩略图
            file.InputStream.Position = 0;//指针复位
            ImageProcessingJob job = new ImageProcessingJob();
            job.Filters.Add(new FixedResizeConstraint(200, 200));//修改图片大小
            job.SaveProcessedImageToFileSystem(file.InputStream, HttpContext.Server.MapPath(thumPath));



            //水印
            file.InputStream.Position = 0;//指针复位
            ImageWatermark imageWatermark = new ImageWatermark(HttpContext.Server.MapPath("~/images/1022035640454473250.png"));//水印的图片
            imageWatermark.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;//水印位置
            imageWatermark.Alpha = 50;//透明等级
            ImageProcessingJob waterJob = new ImageProcessingJob();
            waterJob.Filters.Add(imageWatermark);//插入水印
            waterJob.SaveProcessedImageToFileSystem(file.InputStream, fullPath);

            //file.SaveAs(fullPath);
            return Json(new AjaxResult());
        }
    }
}