using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Y.ZSZ.ManageWeb.Models
{
    public class RoleModel
    {
        public string Name { get; set; }

        public long[] PermissionIds { get; set; }

        public string Description { get; set; }
    }
}