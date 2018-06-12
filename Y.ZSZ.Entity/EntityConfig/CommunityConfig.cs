using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class CommunityConfig:EntityTypeConfiguration<CommunityEntity>
    {
        public CommunityConfig()
        {
            this.ToTable("T_Communities");
            Property(s => s.Name).IsRequired().HasMaxLength(25);
            HasRequired(s => s.RegionEntity).WithMany().HasForeignKey(s => s.RegionId);
        }
    }
}
