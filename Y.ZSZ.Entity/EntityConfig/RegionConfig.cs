using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class RegionConfig:EntityTypeConfiguration<RegionEntity>
    {
        public RegionConfig()
        {
            ToTable("T_Regions");
            Property(s => s.Name).IsRequired().HasMaxLength(20);
            HasRequired(s => s.CityEntity).WithMany().HasForeignKey(s => s.CityId);
        }
    }
}
