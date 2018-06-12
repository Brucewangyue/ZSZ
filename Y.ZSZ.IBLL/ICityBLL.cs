using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;

namespace Y.ZSZ.IBLL
{
    public interface ICityBLL:IAutofacBLL
    {
        /// <summary>
        /// 添加城市
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        long ADD(string name);
        /// <summary>
        /// 根据Id获取城市
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns></returns>
        CityDTO GetModel(long CityId);
        /// <summary>
        /// 获取所有城市
        /// </summary>
        /// <returns></returns>
        List<CityDTO> GetALL();
    }
}
