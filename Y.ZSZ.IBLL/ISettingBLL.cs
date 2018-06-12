using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.IBLL
{
    public interface ISettingBLL:IAutofacBLL
    {
        /// <summary>
        /// 添加数据，返回主键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ADD(string key, string value,string description);
    }
}
