using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO
{
    public class HouseDTO : BaseDTO
    {
        public string Address { get; set; }
        public string CommunityLocation { get; set; }
        public double MonthlyRent { get; set; }
        //面积
        public double Area { get; set; }
        public int TotalFloot { get; set; }
        public int FlootIndex { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Direction { get; set; }
        public DateTime? LookableDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        //描述
        public string Description { get; set; }
        //小区
        public long CommunityId { get; set; }
        public string CommunityName { get; set; }
        //区域
        public long RegionId { get; set; }
        public string RegionName { get; set; }
        //户型
        public long RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        //城市
        public long CityId { get; set; }
        public string CityName { get; set; }
        //状态
        public long? StatusId { get; set; }
        public string StatusName { get; set; }
        //类别(整租合租)
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        //装修
        public long DecorationId { get; set; }
        public string DecorationName { get; set; }
        //房屋图片
        public string FirstHousePic { get; set; }
        //public virtual ICollection<HousePicEntity> HousePicEntitys { get; set; } = new List<HousePicEntity>();

        //房屋配置
        //public long AttachmentId { get; set; }
        //public virtual ICollection<AttachmentEntity> AttachmentEntitys { get; set; } = new List<AttachmentEntity>();
        public long[] AttachmentIds { get; set; }
    }
}
