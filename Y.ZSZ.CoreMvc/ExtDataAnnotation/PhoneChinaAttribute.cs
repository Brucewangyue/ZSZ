using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Y.ZSZ.CoreMvc.ExtDataAnnotation
{
    public  class PhoneChinaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            return base.IsValid(value);
        }
    }
}
