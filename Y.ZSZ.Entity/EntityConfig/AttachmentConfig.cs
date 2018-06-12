using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class AttachmentConfig:EntityTypeConfiguration<AttachmentEntity>
    {
        public AttachmentConfig()
        {
            this.ToTable("T_Attachments");
            Property(s => s.Icon).IsRequired().HasMaxLength(20);
            Property(s => s.Name).IsRequired().HasMaxLength(20);
        }
    }
}
