using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.OptionDTO;

namespace Y.ZSZ.IBLL
{
    public interface IHouseAppointmentBLL:IAutofacBLL
    { /// <summary>
      /// 预约看房
      /// </summary>
      /// <param name="option"></param>
      /// <returns></returns>
        long ADD(HouseAppointmentOption option);
        /// <summary>
        /// 获取预约
        /// </summary>
        /// <returns></returns>
        HouseAppointmentDTO GetById(long appointId);
        /// <summary>
        /// 根据城市获取 预约 分页数据
        /// </summary>
        /// <param name="pageInde"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<HouseAppointmentDTO> GetPageList(long city, int pageInde, int pageSize);
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        long GetTotal(long cityId);
    }
}
