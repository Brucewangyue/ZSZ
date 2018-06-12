using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class HouseConfig : EntityTypeConfiguration<HouseEntity>
    {
        public HouseConfig()
        {
            this.ToTable("T_Houses");
            this.Property(s => s.Address).IsRequired().HasMaxLength(200);
            this.Property(s => s.Area);
            this.Property(s => s.Direction).HasMaxLength(10);
            this.Property(s => s.Description).HasMaxLength(500);
            this.Property(s => s.OwnerName).IsRequired().HasMaxLength(20);//电话
            this.Property(s => s.OwnerPhone).IsRequired().HasMaxLength(20);

            this.HasRequired(s => s.CommunityEntity).WithMany().HasForeignKey(s => s.CommunityId);//小区
            this.HasRequired(s => s.DicRoomTypeEntity).WithMany().HasForeignKey(s => s.RoomTypeId);//户型
            this.HasOptional(s => s.DicStatusEntity).WithMany().HasForeignKey(s => s.StatusId).WillCascadeOnDelete(false);//状态
            this.HasRequired(s => s.DicTypeEntity).WithMany().HasForeignKey(s => s.TypeId).WillCascadeOnDelete(false);//房子类型
            this.HasRequired(s => s.DecorationEntity).WithMany().HasForeignKey(s => s.DecorationId).WillCascadeOnDelete(false);//装修类型
            //this.HasMany(s=>s.HousePicEntitys).WithRequired()
            this.HasMany(s => s.AttachmentEntitys).WithMany(s => s.HouseEntitys).Map(s=>s.ToTable("R_House_Attechment").MapLeftKey("HouseId").MapRightKey("AttachmentId"));//房子配置
        }
    }
}
