using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class HousePicConfig:EntityTypeConfiguration<HousePicEntity>
    {
        public HousePicConfig()
        {
            this.ToTable("T_HousePics");
            this.Property(s => s.Url).IsRequired().HasMaxLength(250);
            this.Property(s => s.ThumUrl).IsRequired().HasMaxLength(250);
            this.HasRequired(s => s.HouseEntity).WithMany(s=>s.HousePicEntitys).HasForeignKey(s=>s.HouseId);
        }
    }
}
