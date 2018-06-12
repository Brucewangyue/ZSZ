using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Y.ZSZ.ManageWeb.App_Start
{
    public class ExcptionFilter : IExceptionFilter
    {
        private static ILog logger = LogManager.GetLogger(typeof(ExcptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception!=null)
            {
                logger.ErrorFormat("出现未处理异常：{0}",filterContext.Exception.Message);

                //throw new Exception(filterContext.Exception.Message);
            }
        }
    }
}