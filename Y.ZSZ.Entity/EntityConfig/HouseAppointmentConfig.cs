using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
   public class HouseAppointmentConfig:EntityTypeConfiguration<HouseAppointmentEntity>
    {
        public HouseAppointmentConfig()
        {
            this.ToTable("T_HouseAppointments");
            this.Property(s => s.Name).IsRequired().HasMaxLength(50);
            this.Property(s => s.Phone).IsRequired().HasMaxLength(25);
            this.Property(s => s.Status).IsRequired().HasMaxLength(50);

            //this.HasRequired(s => s.UserEntity).WithMany().HasForeignKey(s => s.UserId);
            this.HasOptional(s => s.FollowAdminEntity).WithMany().HasForeignKey(s => s.FollowAdminUserId).WillCascadeOnDelete(false);
            this.HasRequired(s => s.HouseEntity).WithMany().HasForeignKey(s => s.HouseId);
        }
    }
}
