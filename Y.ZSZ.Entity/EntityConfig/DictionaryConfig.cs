using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity.EntityConfig
{
    public class DictionaryConfig:EntityTypeConfiguration<DictionaryEntity>
    {
        public DictionaryConfig()
        {
            ToTable("T_Dictionarys");
            Property(s => s.Name).IsRequired().HasMaxLength(250);
            Property(s => s.Type).IsRequired().HasMaxLength(50);

        }
    }
}
