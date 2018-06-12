using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class AdminLogEntity:BaseEntity
    {
        public long UserId { get; set; }
        public UserEntity UserEntity { get; set; }

        public string Msg { get; set; }

    }
}
