using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
namespace Y.ZSZ.CoreMvc
{
    public class NewtonJson : ActionResult
    {
        private static JsonSerializerSettings setting = new JsonSerializerSettings();
        private object _result;
        public NewtonJson(object result)
        {
            _result = result;
            setting.DateFormatString = "yyyy-MM-dd HH:ss";
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver(); //驼峰命名
        }

        public override void ExecuteResult(ControllerContext context)
        {
            //JsonSerializerSettings setting = new JsonSerializerSettings();
          
            var serializer = JsonSerializer.Create(setting);
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";

            serializer.Serialize(response.Output, _result);
        }
    }
}
