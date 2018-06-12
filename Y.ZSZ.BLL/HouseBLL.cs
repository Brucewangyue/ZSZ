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
    public class HouseBLL : IHouseBLL
    {
        public HouseDAL dal = new HouseDAL();

        public long Add(HouseAddOptions model)
        {
            return dal.AddHouse(model);
        }

        public void AddHousePic(long houseId, string fileUrl, string thumUrl)
        {
             dal.AddHousePic(houseId, fileUrl, thumUrl);
        }

        public List<HousePicDTO> GetHousePics(long houseId)
        {
            return dal.GetHousePics(houseId);
        }

        public List<HouseDTO> GetPageData(int pagIndex, int pageSize, out int pageCount)
        {
            return dal.GetPageData(pagIndex, pageSize, out pageCount);
        }
    }
}
