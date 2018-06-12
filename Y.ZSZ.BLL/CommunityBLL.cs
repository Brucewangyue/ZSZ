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
    public class CommunityBLL : ICommunityBLL
    {
        public CommunityDAL dal = new CommunityDAL();
        public List<CommunityDTO> GetByRegionId(long RegionId)
        {
            return dal.GetByRegionId(RegionId);
        }
    }
}
