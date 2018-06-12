using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.Entity;

namespace Y.ZSZ.DAL
{
    public class RegionDAL
    {
        public List<RegionDTO> GetByCityId(long Id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<RegionEntity> dal = new CommonDAL<RegionEntity>(context);
                return dal.GetModels().Where(s => s.CityId == Id).ToList().Select(s => ToDTO(s)).ToList();

            }
        }

        private RegionDTO ToDTO(RegionEntity s)
        {
            if (s == null)
            {
                return null;
            }

            return new RegionDTO
            {
                Id = s.Id,
                Name = s.Name,
                CreateDate = s.CreateDate
            };
        }
    }
}
