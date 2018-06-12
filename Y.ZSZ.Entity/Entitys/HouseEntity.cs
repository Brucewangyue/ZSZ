using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class HouseEntity : BaseEntity
    {
        public string Address { get; set; }

        public double MonthlyRent { get; set; }

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

        public string Description { get; set; }

        public long CommunityId { get; set; }
        public virtual CommunityEntity CommunityEntity { get; set; }
        //户型
        public long RoomTypeId { get; set; }
        public virtual DictionaryEntity DicRoomTypeEntity { get; set; }

        public long? StatusId { get; set; }
        public virtual DictionaryEntity DicStatusEntity { get; set; }

        public long DecorationId { get; set; }
        public virtual DictionaryEntity DecorationEntity { get; set; }

        //类别
        public long TypeId { get; set; }
        public virtual DictionaryEntity DicTypeEntity { get; set; }

        //房屋图片
        //public long HousePicId { get; set; }
        public virtual ICollection<HousePicEntity> HousePicEntitys { get; set; } = new List<HousePicEntity>();

        //房屋配置
        //public long AttachmentId { get; set; }
        public virtual ICollection<AttachmentEntity> AttachmentEntitys { get; set; } = new List<AttachmentEntity>();
    }
}
