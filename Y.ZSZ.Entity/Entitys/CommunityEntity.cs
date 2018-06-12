using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class CommunityEntity:BaseEntity
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string Traffic { get; set; }

        public int BuiltYear { get; set; }

        public long RegionId { get; set; }
        public virtual RegionEntity RegionEntity { get; set; }

    }
}
