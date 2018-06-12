using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO.OptionDTO
{
   public  class HouseOption
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
        //户型
        public long RoomTypeId { get; set; }

        public long StatusId { get; set; }

        //类别
        public long TypeId { get; set; }

        public long DecorationId { get; set; }

        //房屋配置
        public long[] AttachmentIds { get; set; }
    }
}
