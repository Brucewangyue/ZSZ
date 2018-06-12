using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;

namespace Y.ZSZ.IBLL
{
    public interface IRegionBLL:IAutofacBLL
    {
        List<RegionDTO> GetByCityId(long Id);
    }
}
