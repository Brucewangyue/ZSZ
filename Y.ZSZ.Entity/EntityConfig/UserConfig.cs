using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class UserConfig:EntityTypeConfiguration<UserEntity>
    {
        public UserConfig()
        {
            this.ToTable("T_Users");
            this.Property(s => s.Phone).IsRequired().HasMaxLength(20).IsUnicode(false);
            this.Property(s => s.PasswordHash).IsRequired().HasMaxLength(100).IsUnicode(false);
            this.Property(s => s.PasswordSalt).IsRequired().HasMaxLength(100).IsUnicode(false);

        }
    }
}
