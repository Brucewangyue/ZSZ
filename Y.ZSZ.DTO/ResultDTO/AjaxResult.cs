using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO.ResultDTO
{
    public class AjaxResult
    {
        public string Status { get; set; } = "ok";
        public object Data { get; set; }
        public string Msg { get; set; }
    }
}
