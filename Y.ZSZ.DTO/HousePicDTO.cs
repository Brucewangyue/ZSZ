using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO
{
    public class HousePicDTO : BaseDTO
    {
        public string Url { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumUrl { get; set; }

        public long HouseId { get; set; }
    }
}
