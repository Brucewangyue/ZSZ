using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Y.ZSZ.CoreMvc.ExtDataAnnotation;

namespace Y.ZSZ.ManageWeb.Models
{
    public class AdminUserAddModel
    {
        [Required]
        [StringLength(16,MinimumLength =6)]
        public string Pwd { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 6)]
        public string ReCheckPwd { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Phone]
        [PhoneChina]
        public string PhoneNum { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public long CityId { get; set; }
        public long[] RoleIds { get; set; }
    }
}