using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.IBLL;
using Y.ZSZ.DAL;

namespace Y.ZSZ.BLL
{
    public class CityBLL : ICityBLL
    {
        public CityDAL dal = new CityDAL();
        public long ADD(string name)
        {
            return dal.ADD(name);
        }

        public List<CityDTO> GetALL()
        {
            return dal.GetALL();
        }

        public CityDTO GetModel(long CityId)
        {
            return dal.GetModel(CityId);
        }
    }
}
