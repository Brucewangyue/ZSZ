using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Y.ZSZ.CoreMvc
{
    public class ValidModelState
    {
        public static string Valid(ModelStateDictionary model)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in model.Keys)
            {
                ModelState modelState = model[key];
                foreach (ModelError error in modelState.Errors)
                {
                    sb.Append("属性【").Append(key).Append("】:").Append(error.ErrorMessage);
                    sb.Append("--");
                }
            }
            return sb.ToString();
        }
    }
}
