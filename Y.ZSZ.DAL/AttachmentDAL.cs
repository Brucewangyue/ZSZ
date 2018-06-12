using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.Entity;
using System.Data.Entity;
using Y.ZSZ.DTO;
namespace Y.ZSZ.DAL
{
    public class AttachmentDAL
    {

        /// <summary>
        /// 获取房屋的设施配置
        /// </summary>
        /// <param name="HouseId"></param>
        /// <returns></returns>
        public List<AttachmentDTO> GetAttachment(long HouseId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HouseEntity> houseDal = new CommonDAL<HouseEntity>(context);
                HouseEntity house = houseDal.GetModels().Include(s => s.AttachmentEntitys).SingleOrDefault(s => s.Id == HouseId);
                if (house == null)
                {
                    throw new ArgumentException("没有Id：" + HouseId + "的房屋记录");
                }

                return house.AttachmentEntitys.Select(s => ToDTO(s)).ToList();
            }
        }

        private AttachmentDTO ToDTO(AttachmentEntity s)
        {
            if (s == null)
            {
                return null;
            }
            return new AttachmentDTO
            {
                Name = s.Name,
                Id = s.Id,
                CreateDate = s.CreateDate,
                Icon = s.Icon
            };

        }
    }
}
