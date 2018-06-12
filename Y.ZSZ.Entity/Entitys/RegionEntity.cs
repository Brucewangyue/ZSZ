using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class RegionEntity:BaseEntity
    {
        public string Name { get; set; }

        public long CityId{ get; set; }
        public virtual CityEntity CityEntity { get; set; }
    }
}
