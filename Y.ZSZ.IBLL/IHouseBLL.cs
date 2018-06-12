using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.OptionDTO;

namespace Y.ZSZ.IBLL
{
    public interface IHouseBLL : IAutofacBLL
    {
        List<HouseDTO> GetPageData(int pagIndex, int pageSize, out int pageCount);
        long Add(HouseAddOptions model);
        void AddHousePic(long houseId, string fileUrl, string thumUrl);
        List<HousePicDTO> GetHousePics(long houseId);
    }
}
