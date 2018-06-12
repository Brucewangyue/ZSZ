using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DAL;
using Y.ZSZ.DTO;
using Y.ZSZ.IBLL;

namespace Y.ZSZ.BLL
{
  
    public class RegionBLL: IRegionBLL
    {
        public RegionDAL dal = new RegionDAL();
        public List<RegionDTO> GetByCityId(long Id)
        {
            return dal.GetByCityId(Id);
        }
    }
}
