using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class SettingEntity: BaseEntity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
