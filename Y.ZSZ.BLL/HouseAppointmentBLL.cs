using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DAL;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.OptionDTO;
using Y.ZSZ.IBLL;

namespace Y.ZSZ.BLL
{
    public class HouseAppointmentBLL : IHouseAppointmentBLL
    {
        private static HouseAppointmentDAL dal = new HouseAppointmentDAL();

        public long ADD(HouseAppointmentOption option)
        {
            return dal.ADD(option);
        }

        public HouseAppointmentDTO GetById(long appointId)
        {
            return dal.GetById(appointId);
        }

        public List<HouseAppointmentDTO> GetPageList(long city, int pageInde, int pageSize)
        {
            return dal.GetPageList(city, pageInde, pageSize);
        }

        public long GetTotal(long cityId)
        {
            return dal.GetTotal(cityId);
        }
    }
}
