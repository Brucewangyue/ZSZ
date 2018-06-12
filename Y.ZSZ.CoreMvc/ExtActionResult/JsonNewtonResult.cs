using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web;
namespace Y.ZSZ.CoreMvc.ExtActionResult
{
    public class JsonNewtonResult : JsonResult
    {
        private JsonSerializerSettings jsonSetting = new JsonSerializerSettings();

        public JsonNewtonResult()
        {
            jsonSetting.DateFormatString = "yyyy-MM-dd HH:mm";
            jsonSetting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;//忽略循环引用
            jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        /// <summary>
        /// 这个是最后改变返回值的地方，在 OnActionExecuted 时调用这个方法。之后的resultExecuting都无法再改变输出格式
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet
                && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidCastException("不允许Get请求");
            }

            HttpResponseBase response = context.HttpContext.Response;
            //设置默认的输出类型
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;


            
            JsonSerializer jsonSerializer = JsonSerializer.Create(jsonSetting);
            jsonSerializer.Serialize(response.Output, this.Data);
        }
    }
}
