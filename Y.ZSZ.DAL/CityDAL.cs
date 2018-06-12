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
    public class CityDAL
    {
        /// <summary>
        /// 添加城市
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public long ADD(string name)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<CityEntity> cityDal = new CommonDAL<CityEntity>(context);
                if (cityDal.Any(s => s.Name == name))
                {
                    throw new ArgumentException("该城市：" + name + "已经存在");
                }

                CityEntity city = new CityEntity();
                city.Name = name;
                context.Cities.Add(city);
                context.SaveChanges();
                return city.Id;
            }
        }
        /// <summary>
        /// 根据Id获取城市
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns></returns>
        public CityDTO GetModel(long CityId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<CityEntity> cityDal = new CommonDAL<CityEntity>(context);
                CityEntity city = cityDal.GetModel(CityId);
                return ToDTO(city);
            }
        }

        /// <summary>
        /// 获取所有城市
        /// </summary>
        /// <returns></returns>
        public List<CityDTO> GetALL()
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<CityEntity> cityDal = new CommonDAL<CityEntity>(context);
                return cityDal.GetModels().AsNoTracking().ToList().Select(s=>ToDTO(s)).ToList();
            }
        }

        private CityDTO ToDTO(CityEntity city)
        {
            if (city == null)
            {
                return null;
            }

            return new CityDTO
            {
                Name = city.Name,
                Id = city.Id,
                CreateDate = city.CreateDate
            };
        }
    }
}
