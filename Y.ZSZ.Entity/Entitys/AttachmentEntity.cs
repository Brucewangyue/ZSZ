using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public class AttachmentEntity:BaseEntity
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<HouseEntity> HouseEntitys { get; set; } = new List<HouseEntity>();
    }
}
