using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO
{
    public class HouseAppointmentDTO:BaseDTO
    {
        public long UserId { get; set; }
        //public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime VisitDate { get; set; }
        public long HouseId { get; set; }
        public string Status { get; set; }
        public long? FollowAdminUserId { get; set; }
        public string FollowAdminUserName { get; set; }
        public DateTime? FollowDate { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; }
        public long RegionId { get; set; }
        public string RegionName { get; set; }
        public long CommunityId { get; set; }
        public string CommunityName { get; set; }
    }
}
