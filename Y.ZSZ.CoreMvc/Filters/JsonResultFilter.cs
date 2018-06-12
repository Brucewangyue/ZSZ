using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc.ExtActionResult;

namespace Y.ZSZ.CoreMvc.Filters
{
    public class JsonResultFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is JsonResult)
            {
                JsonResult jsonResult = (JsonResult)filterContext.Result;
                JsonNewtonResult jsonNewtonResult = new JsonNewtonResult();
                jsonNewtonResult.ContentEncoding = jsonResult.ContentEncoding;
                jsonNewtonResult.ContentType = jsonResult.ContentType;
                jsonNewtonResult.Data = jsonResult.Data;
                jsonNewtonResult.JsonRequestBehavior = jsonResult.JsonRequestBehavior;
                jsonNewtonResult.MaxJsonLength = jsonResult.MaxJsonLength;
                jsonNewtonResult.RecursionLimit = jsonResult.RecursionLimit;
                //设置
                filterContext.Result = jsonNewtonResult;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }

        #region OnResultExecuted迟了，改变不了输出   
        ////当前端都渲染成字符串了最后再跑回来执行
        //public void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    //if (filterContext.Result is JsonResult)
        //    //{
        //    //    JsonResult jsonResult = (JsonResult)filterContext.Result;
        //    //    JsonNewtonResult jsonNewtonResult = new JsonNewtonResult();
        //    //    jsonNewtonResult.ContentEncoding = jsonResult.ContentEncoding;
        //    //    jsonNewtonResult.ContentType = jsonResult.ContentType;
        //    //    jsonNewtonResult.Data = jsonResult.Data;
        //    //    jsonNewtonResult.JsonRequestBehavior = jsonResult.JsonRequestBehavior;
        //    //    jsonNewtonResult.MaxJsonLength = jsonResult.MaxJsonLength;
        //    //    jsonNewtonResult.RecursionLimit = jsonResult.RecursionLimit;
        //    //    //设置
        //    //    filterContext.Result = jsonNewtonResult;
        //    //}
        //}

        //public void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    if (filterContext.Result is JsonResult)
        //    {
        //        JsonResult jsonResult = (JsonResult)filterContext.Result;
        //        JsonNewtonResult jsonNewtonResult = new JsonNewtonResult();
        //        jsonNewtonResult.ContentEncoding = jsonResult.ContentEncoding;
        //        jsonNewtonResult.ContentType = jsonResult.ContentType;
        //        jsonNewtonResult.Data = jsonResult.Data;
        //        jsonNewtonResult.JsonRequestBehavior = jsonResult.JsonRequestBehavior;
        //        jsonNewtonResult.MaxJsonLength = jsonResult.MaxJsonLength;
        //        jsonNewtonResult.RecursionLimit = jsonResult.RecursionLimit;
        //        //设置
        //        filterContext.Result = jsonNewtonResult;
        //    }
        //}
        #endregion
    }
}
