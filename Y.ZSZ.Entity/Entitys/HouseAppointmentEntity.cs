using System;

namespace Y.ZSZ.Entity
{
    public class HouseAppointmentEntity:BaseEntity
    {
        public long UserId { get; set; }
        //public UserEntity UserEntity { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime VisitDate { get; set; }

        public long HouseId{get;set;}
        public virtual HouseEntity HouseEntity { get; set; }

        public string Status { get; set; }

        public long? FollowAdminUserId { get; set; }
        public virtual AdminUserEntity FollowAdminEntity { get; set; }

        public DateTime? FollowDate { get; set; }
    }
}
