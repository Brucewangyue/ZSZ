using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.Entity;
using System.Data.Entity;
using Y.ZSZ.DTO;
using Y.ZSZ.DTO.OptionDTO;

namespace Y.ZSZ.DAL
{
    public class HouseDAL
    {
        /// <summary>
        /// 获取一个房子
        /// </summary>
        /// <param name="HouseId"></param>
        /// <returns></returns>
        public List<HouseDTO> GetPageData(int pagIndex, int pageSize, out int pageCount)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HouseEntity> dal = new CommonDAL<HouseEntity>(context);
                CommonDAL<AttachmentEntity> attachmentDal = new CommonDAL<AttachmentEntity>(context);

                pageCount = dal.GetModels().Count();

                return dal.GetModels()
                    .Include(s => s.DicRoomTypeEntity)
                    .Include(s => s.DicStatusEntity)
                     .Include(s => s.DecorationEntity)
                    .Include(s => s.DicTypeEntity)
                    //.Include(s => s.AttachmentEntitys)//多对多的设施，也是直接连
                    .Include(s => s.CommunityEntity)//小区
                    .Include(nameof(CommunityEntity) + "." + nameof(RegionEntity))//区域
                    .Include(nameof(CommunityEntity) + "." + nameof(RegionEntity) + "." + nameof(CityEntity))//城市
                                                                                                             //.Include(s => s.HousePicEntitys)//配置反向属性，或者Linq
                    .AsNoTracking()
                    //.OrderByDescending(s => s.CreateDate).Skip(pagIndex-1).Take(pageSize)
                    .ToList().Select(s => ToDTO(s)).ToList();
            }
        }

        //添加房源图片
        public void AddHousePic(long houseId, string fileUrl, string thumUrl)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                HousePicEntity housePicEntity = new HousePicEntity();
                housePicEntity.HouseId = houseId;
                housePicEntity.ThumUrl = thumUrl;
                housePicEntity.Url = fileUrl;
                context.HousePics.Add(housePicEntity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 获取一个房子
        /// </summary>
        /// <param name="HouseId"></param>
        /// <returns></returns>
        public HouseDTO GetById(long HouseId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HouseEntity> dal = new CommonDAL<HouseEntity>(context);
                CommonDAL<AttachmentEntity> attachmentDal = new CommonDAL<AttachmentEntity>(context);
                //attachmentDal.GetModel(s => s.HouseEntitys.Where(s => s.Id == HouseId).Select());

                return ToDTO(dal.GetModels()
                    .Include(s => s.DicRoomTypeEntity)
                    .Include(s => s.DicStatusEntity)
                    .Include(s => s.DecorationEntity)
                    .Include(s => s.DicTypeEntity)
                    //.Include(s => s.AttachmentEntitys)//多对多的设施，也是直接连
                    .Include(s => s.CommunityEntity)//小区
                    .Include(nameof(CommunityEntity) + "." + nameof(RegionEntity))//区域
                    .Include(nameof(CommunityEntity) + "." + nameof(RegionEntity) + "." + nameof(CityEntity))//城市
                                                                                                             //.Include(s => s.HousePicEntitys)//配置反向属性，或者Linq
                    .SingleOrDefault(s => s.Id == HouseId));

            }
        }

        private HouseDTO ToDTO(HouseEntity houseEntity)
        {
            if (houseEntity == null) return null;

            return new HouseDTO
            {
                Address = houseEntity.Address,
                Area = houseEntity.Area,
                //AttachmentIds = houseEntity.AttachmentEntitys.Select(s => s.Id).ToArray(),
                DecorationId = houseEntity.DecorationId,
                DecorationName = houseEntity.DecorationEntity.Name,
                CheckInDate = houseEntity.CheckInDate,
                CommunityId = houseEntity.CommunityId,
                CommunityName = houseEntity.CommunityEntity.Name,
                CreateDate = houseEntity.CreateDate,
                Description = houseEntity.Description,
                Id = houseEntity.Id,
                CommunityLocation = houseEntity.CommunityEntity.Location,
                Direction = houseEntity.Direction,
                FlootIndex = houseEntity.FlootIndex,
                LookableDate = houseEntity.LookableDate,
                MonthlyRent = houseEntity.MonthlyRent,
                OwnerName = houseEntity.OwnerName,
                OwnerPhone = houseEntity.OwnerPhone,
                //FirstHousePic = houseEntity.HousePicEntitys.FirstOrDefault() != null?houseEntity.HousePicEntitys.FirstOrDefault().ThumUrl:null,
                RoomTypeId = houseEntity.RoomTypeId,
                RoomTypeName = houseEntity.DicRoomTypeEntity.Name,
                RegionId = houseEntity.CommunityEntity.RegionId,
                RegionName = houseEntity.CommunityEntity.RegionEntity.Name,
                CityId = houseEntity.CommunityEntity.RegionEntity.CityId,
                CityName = houseEntity.CommunityEntity.RegionEntity.CityEntity.Name,
                StatusId = houseEntity.StatusId,
                StatusName = houseEntity.DicStatusEntity.Name,
                TotalFloot = houseEntity.TotalFloot,
                TypeId = houseEntity.TypeId,
                TypeName = houseEntity.DicTypeEntity.Name
            };
        }
        /// <summary>
        /// 新增房子
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public long AddHouse(HouseAddOptions option)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AttachmentEntity> attachDal = new CommonDAL<AttachmentEntity>(context);
                HouseEntity house = new HouseEntity
                {
                    Address = option.Address,
                    Area = option.Area,
                    CheckInDate = option.CheckInDate,
                    CommunityId = option.CommunityId,
                    Description = option.Description,
                    Direction = option.Direction,
                    FlootIndex = option.FlootIndex,
                    LookableDate = option.LookableDate,
                    MonthlyRent = option.MonthlyRent,
                    OwnerName = option.OwnerName,
                    OwnerPhone = option.OwnerPhone,
                    RoomTypeId = option.RoomTypeId,
                    StatusId = option.StatusId,
                    TotalFloot = option.TotalFloot,
                    TypeId = option.TypeId,
                    DecorationId = option.DecorationId,
                };
                if (option.AttachmentIds != null)
                {
                    foreach (var item in option.AttachmentIds)
                    {
                        //AttachmentEntity entity = new AttachmentEntity { Id = item };
                        AttachmentEntity entity = attachDal.GetModel(item);
                        house.AttachmentEntitys.Add(entity);
                    }
                }

                context.Houses.Add(house);
                context.SaveChanges();
                return house.Id;
            }
        }
        public List<HousePicDTO> GetHousePics(long houseId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<HousePicEntity> dal = new CommonDAL<HousePicEntity>(context);
                return dal.GetModels(s => s.HouseId == houseId).ToList().Select(s => ToPicDTO(s)).ToList();
            }
        }

        private HousePicDTO ToPicDTO(HousePicEntity s)
        {
            if (s == null)
            {
                return null;
            }

            return new HousePicDTO
            {
                CreateDate = s.CreateDate,
                HouseId = s.HouseId,
                Id = s.Id,
                ThumUrl = s.ThumUrl,
                Url = s.Url,
            };
        }
    }
}
