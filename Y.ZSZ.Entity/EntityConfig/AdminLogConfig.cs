using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class AdminLogConfig:EntityTypeConfiguration<AdminLogEntity>
    {
        public AdminLogConfig()
        {
            this.ToTable("T_AdminLogs");
            this.Property(s => s.Msg).IsRequired();
            this.HasRequired(s => s.UserEntity).WithMany().HasForeignKey(s => s.UserId);
        }
    }
}
