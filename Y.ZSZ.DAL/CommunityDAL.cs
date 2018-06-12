using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.Entity;

namespace Y.ZSZ.DAL
{
    public class CommunityDAL
    {
        /// <summary>
        /// 根据区域获取所有小区
        /// </summary>
        /// <param name="RegionId"></param>
        /// <returns></returns>
        public List<CommunityDTO> GetByRegionId(long RegionId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<CommunityEntity> dal = new CommonDAL<CommunityEntity>(context);
                return dal.GetModels().AsNoTracking().Where(s => s.RegionId == RegionId)//.Include(s => s.RegionEntity)暂时用不到
                    .ToList().Select(s => ToDTO(s)).ToList();
            }
        }

        private CommunityDTO ToDTO(CommunityEntity s)
        {
            if (s == null)
            {
                return null;
            }

            return new CommunityDTO
            {
                Name = s.Name,
                BuiltYear = s.BuiltYear,
                CreateDate = s.CreateDate,
                Id = s.Id,
                Location = s.Location,
                RegionId = s.RegionId,
                //RegionName = s.RegionEntity.Name,
                Traffic = s.Traffic
            };

        }
    }
}
