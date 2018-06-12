using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    class RoleConfig: EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfig()
        {
            ToTable("T_Roles");
            HasMany(r => r.Permissions).WithMany(p => p.Roles).Map(m=>m.ToTable("R_RolePermissions")
                .MapLeftKey("RoleId").MapRightKey("PermissionId"));
            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.Description).HasMaxLength(250);
        }
    }
}
