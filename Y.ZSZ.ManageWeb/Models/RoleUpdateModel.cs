using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Y.ZSZ.DTO;

namespace Y.ZSZ.ManageWeb.Models
{
    public class RoleUpdateModel
    {
        public RoleDTO Role { get; set; }
        public List<PermissionDTO> Permissions { get; set; }
    }
}