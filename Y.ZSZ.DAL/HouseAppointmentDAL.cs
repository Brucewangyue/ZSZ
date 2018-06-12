using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.OptionDTO;
using Y.ZSZ.Entity;
namespace Y.ZSZ.DAL
{
    public class HouseAppointmentDAL
    {
        /// <summary>
        /// 预约看房
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public long ADD(HouseAppointmentOption option)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                HouseAppointmentEntity entity = new HouseAppointmentEntity
                {
                    HouseId = option.HouseId,
                    Name = option.Name,
                    Phone = option.Phone,
                    Status = option.Status,
                    UserId = option.UserId,
                    VisitDate = option.VisitDate
                };
                context.HouseAppointments.Add(entity);
                return entity.Id;
            }
        }
        /// <summary>
        /// 获取预约
        /// </summary>
        /// <returns></returns>
        public HouseAppointmentDTO GetById(long appointId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HouseAppointmentEntity> dal = new CommonDAL<HouseAppointmentEntity>(context);
                HouseAppointmentEntity houseAppiont = dal.GetModels()
                    //.Include(s => s.UserEntity)
                    .Include(s => s.FollowAdminEntity)
                    .Include(s => s.HouseEntity)
                    .Include(nameof(HouseEntity) + "." + nameof(CommunityEntity))
                    .Include(nameof(HouseEntity) + "." + nameof(CommunityEntity) + "." + nameof(RegionEntity))
                    .AsNoTracking()
                    .SingleOrDefault(s => s.Id == appointId);
                return ToDTO(houseAppiont);
            }
        }
        /// <summary>
        /// 根据城市获取 预约 分页数据
        /// </summary>
        /// <param name="pageInde"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<HouseAppointmentDTO> GetPageList(long city, int pageInde, int pageSize)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HouseAppointmentEntity> dal = new CommonDAL<HouseAppointmentEntity>(context);
                //
                List<HouseAppointmentDTO> ss = (from houseAppoin in context.HouseAppointments.Where(s => s.IsDelete == false)
                                                join aUser in context.AdminUsers on houseAppoin.FollowAdminUserId equals aUser.Id
                                                join house in context.Houses on houseAppoin.HouseId equals house.Id
                                                join communi in context.Communitys on houseAppoin.HouseEntity.CommunityId equals communi.Id
                                                join region in context.Regions on houseAppoin.HouseEntity.CommunityEntity.RegionId equals region.Id
                                                where region.CityId== city
                                                orderby houseAppoin.CreateDate descending
                                                select ToDTO(houseAppoin)).ToList();

                List<HouseAppointmentDTO> result = dal.GetModels()
                    .Include(s => s.FollowAdminEntity)
                    .Include(s => s.HouseEntity)
                    .Include(nameof(HouseEntity) + "." + nameof(CommunityEntity))
                    .Include(nameof(HouseEntity) + "." + nameof(CommunityEntity) + "." + nameof(RegionEntity))
                    .Where(s => s.HouseEntity.CommunityEntity.RegionEntity.CityId == city)
                    .OrderByDescending(s => s.CreateDate)
                    .Skip(pageInde).Take(pageSize)
                    .Select(s => ToDTO(s)).ToList();

                return result;
            }
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public long GetTotal(long cityId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HouseAppointmentEntity> dal = new CommonDAL<HouseAppointmentEntity>(context);
                return dal.GetModels()
                    .LongCount(s => s.HouseEntity.CommunityEntity.RegionEntity.CityId == cityId);
            }
        }

        //
        private HouseAppointmentDTO ToDTO(HouseAppointmentEntity houseAppiont)
        {
            if (houseAppiont == null) return null;

            return new HouseAppointmentDTO
            {
                CommunityId = houseAppiont.HouseEntity.CommunityId,
                CommunityName = houseAppiont.HouseEntity.CommunityEntity.Name,
                RegionId = houseAppiont.HouseEntity.CommunityEntity.RegionId,
                RegionName = houseAppiont.HouseEntity.CommunityEntity.RegionEntity.Name,
                CreateDate = houseAppiont.CreateDate,
                FollowAdminUserId = houseAppiont.FollowAdminUserId,
                FollowAdminUserName = houseAppiont.FollowAdminEntity.Name,
                FollowDate = houseAppiont.FollowDate,
                HouseId = houseAppiont.HouseId,
                Id = houseAppiont.Id,
                Name = houseAppiont.Name,
                Phone = houseAppiont.Phone,
                Status = houseAppiont.Status,
                UserId = houseAppiont.Id,
                VisitDate = houseAppiont.VisitDate
            };
        }


    }
}
