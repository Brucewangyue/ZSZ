using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO
{
    public class RoleDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string AdminsUserNames { get; set; }

        public long[] PermissionIds { get; set; }
    }
}
