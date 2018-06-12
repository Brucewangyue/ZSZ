using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class UserEntity:BaseEntity
    {
        public string Phone { get; set; }
        /// <summary>
        /// 密码Hash
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// 密码盐
        /// </summary>
        public string PasswordSalt { get; set; }

        public int LoginErrorTimes { get; set; } 

        public DateTime? LastErrorDate { get; set; }

        public long CityId { get; set; }
        public CityEntity CityEntity { get; set; }

    }
}

