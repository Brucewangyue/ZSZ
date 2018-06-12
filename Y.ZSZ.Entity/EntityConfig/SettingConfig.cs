using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    class SettingConfig:EntityTypeConfiguration<SettingEntity>
    {
        public SettingConfig()
        {
            this.ToTable("T_Settings");
            Property(s => s.Key).IsRequired().HasMaxLength(250);
            Property(s => s.Value).IsRequired();
        }
    }
}
